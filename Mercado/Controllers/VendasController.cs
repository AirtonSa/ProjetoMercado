using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.Models;
using Mercado.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Controllers
{
    public class VendasController : Controller
    {
        private readonly IVendasRepository vendasRepository;
        private readonly IProdutoRepository produtoRepository;
        private readonly IEstoqueRepository estoqueRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ITipolancamentoRepository tipolancamentoRepository;

        public VendasController(IVendasRepository vendasRepository, IProdutoRepository produtoRepository, IEstoqueRepository estoqueRepository, IUsuarioRepository usuarioRepository, ITipolancamentoRepository tipolancamentoRepository)
        {
            this.vendasRepository = vendasRepository;
            this.produtoRepository = produtoRepository;
            this.estoqueRepository = estoqueRepository;
            this.usuarioRepository = usuarioRepository;
            this.tipolancamentoRepository = tipolancamentoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConfirmarVendas()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AjaxVendas([FromBody] List<VendaViewModel> listaViewModel)
        {
            #region listalin1
            //f9
            //var lista_venda_linq = listaViewModel.Select(v => new Vendas
            //{
            //    Produto = produtoRepository.BuscaporId(Convert.ToInt32(v.idProduto)),
            //    quantidade = v.quantidade,
            //    ValorTotal = v.ValorTotal
            //}).ToList();
            #endregion
            var listaDeVenda = new List<Vendas>();
            var NovaListaEstoque = new List<Estoque>();

            for(var i = 0; i <listaViewModel.Count(); i++)
            {
                var venda = new Vendas();
                var estoque = new Estoque();
               
                venda.Produto = produtoRepository.BuscaporId(Convert.ToInt32(listaViewModel[i].idProduto));
                venda.Usuario = usuarioRepository.BuscarUsuarioporId(1);
                venda.quantidade = (listaViewModel[i].quantidade);
                venda.ValorTotal = listaViewModel[i].ValorTotal;
                listaDeVenda.Add(venda);


                estoque.TipoLancamento = tipolancamentoRepository.BuscarDescricaoporid(2);
                estoque.Produto = venda.Produto;
                estoque.Quantidade = Convert.ToInt32(venda.quantidade);
                estoque.Usuario = venda.Usuario;
                NovaListaEstoque.Add(estoque);


                var estoquecomparametro = new Estoque(Convert.ToInt32(venda.quantidade), venda.Produto, venda.Usuario,
                    tipolancamentoRepository.BuscarDescricaoporid(2));

                
                
            }
            
          
            for(var i = 0; i < listaDeVenda.Count(); i++)
            {
                var venda = listaDeVenda[i].Id;
                
                //vendasRepository.SalvarVenda(listaDeVenda[i]);
                vendasRepository.SalvarlistaVenda(listaDeVenda);
                //vendasRepository.SalvarVenda();
                
            }
            


            for (var i = 0; i < NovaListaEstoque.Count(); i++)
            {
                var estoque = NovaListaEstoque[i].Id;

                //estoqueRepository.SalvarEstoque(NovaListaEstoque[i]); // salvar lista de um por um
                estoqueRepository.SalvarListaEstoque(NovaListaEstoque); // salva a lista por completo

            }
            
            

            var msgRetorno = "";
            for(var i = 0; i < listaDeVenda.Count(); i++)
            {
                var listaId = listaDeVenda[i].Id;
                
                if (listaId == 0)
                {
                    msgRetorno = "Venda não Salva";
                }
                else
                {
                    msgRetorno = "Venda Salva";

                }

            }

            var lista = new List<Vendas>();
            #region comentario
            //foreach(var i in listaViewModel)
            //{
            //    var venda = new Vendas();

            //    venda.Produto = produtoRepository.BuscaporId(Convert.ToInt32(i.idProduto));
            //    venda.quantidade = i.quantidade;
            //    venda.Usuario = usuarioRepository.BuscarUsuarioporId(1);
            //    venda.ValorTotal = i.ValorTotal;

            //    lista.Add(venda);
            //}

            //foreach(var i in lista)
            //{
            //    //vendasRepository.SalvarVenda(i);

            //}

            //var msg = "";

            //foreach(var i in lista)
            //{
            //    var idvenda = i.Id;
            //    if(idvenda == 0)
            //    {
            //        msg = "Venda não salva";
            //    }else
            //    {
            //        msg = "venda Salva";
            //    }

            //}


            //var lista = 

            //foreach e o for 

            //#region listalin1

            //var listas = new List<Vendas>(); //3
            //                                 // para i é varialiicial , i<tamanhoarraylista, i = incremento em +1
            //for (int i = 0; i < listaViewModel.Count(); i++)
            //{
            //    var venda = new Vendas();

            //    venda.Produto = produtoRepository.BuscaporId(Convert.ToInt32(listaViewModel[i].idProduto)); //acesso a posição de cada passagem no i f11
            //    venda.quantidade = listaViewModel[i].quantidade;
            //    venda.ValorTotal = listaViewModel[i].ValorTotal;
            //    venda.Usuario = usuarioRepository.BuscarUsuarioporId(1);
            //    listas.Add(venda); //adiciono na lista 

            //}

            //for (int posicaoinicial = 0; posicaoinicial < listas.Count(); posicaoinicial++)
            //{


            //    var Venda = listas[posicaoinicial];

            //   // vendasRepository.SalvarVenda(Venda);

            //}

            //#endregion

            //var Est = produtoRepository.RetornaProduto(listaViewModel);
            #endregion

            
            //var estoque = new Estoque();

            //estoque.TipoLancamento = repolct.buscaporid(1); //id 1 igual debito

           

            return Json(msgRetorno);
        }

        public IActionResult RetornarVenda()
        {
            var ListaVenda = vendasRepository.BuscarListaVenda();

            var calculo = ListaVenda.GroupBy(x => new { idProduto = x.Produto })
                .Select(s => new Vendas { Produto = s.Key.idProduto}).ToList();

            var Calculo = ListaVenda.GroupBy(x => new { ProdutoAgrupado = x.Produto })
                .Select(s => new Vendas 
                { 
                  Produto = s.Key.ProdutoAgrupado, 
                  quantidade=s.Sum(x=>Convert.ToInt32(x.quantidade)).ToString(),
                  ValorTotal = s.Sum(x=>x.ValorTotal)
                }).ToList(); 

            return View(Calculo);
        }
    }
}