using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.Models;
using Mercado.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Controllers
{
    public class VendasController : Controller
    {
        private readonly IPedidoRepository vendasRepository;
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidooRepository;
        private readonly IEstoqueRepository estoqueRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ITipolancamentoRepository tipolancamentoRepository;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IStatusPedidoRepository statuspedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public VendasController(IPedidoRepository vendasRepository, IProdutoRepository produtoRepository, IEstoqueRepository estoqueRepository, 
            IUsuarioRepository usuarioRepository, ITipolancamentoRepository tipolancamentoRepository, IHttpContextAccessor contextAccessor,
            IPedidoRepository pedidooRepository, IStatusPedidoRepository statuspedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this.vendasRepository = vendasRepository;
            this.produtoRepository = produtoRepository;
            this.estoqueRepository = estoqueRepository;
            this.usuarioRepository = usuarioRepository;
            this.tipolancamentoRepository = tipolancamentoRepository;
            this.contextAccessor = contextAccessor;
            this.pedidooRepository = pedidooRepository;
            this.statuspedidoRepository = statuspedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
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
            var listaDeVenda = new List<Pedido>();
            var NovaListaEstoque = new List<Estoque>();

            for(var i = 0; i <listaViewModel.Count(); i++)
            {
                var venda = new Pedido();
                var estoque = new Estoque();
               
                //venda.Produto = produtoRepository.BuscaporId(Convert.ToInt32(listaViewModel[i].idProduto));
                venda.Usuario = usuarioRepository.BuscarUsuarioporId(1);
                //venda.quantidade = (listaViewModel[i].quantidade);
                //venda.ValorTotal = listaViewModel[i].ValorTotal;
                listaDeVenda.Add(venda);


                estoque.TipoLancamento = tipolancamentoRepository.BuscarDescricaoporid(2);
                //estoque.Produto = venda.Produto;
                //estoque.Quantidade = Convert.ToInt32(venda.quantidade);
                estoque.Usuario = venda.Usuario;
                NovaListaEstoque.Add(estoque);


               // var estoquecomparametro = new Estoque(Convert.ToInt32(venda.quantidade), venda.Produto, venda.Usuario,tipolancamentoRepository.BuscarDescricaoporid(2));

                
                
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

            //var calculo = ListaVenda.GroupBy(x => new { idProduto = x.Id })
            //    .Select(s => new Vendas { Produto = s.Key.idProduto}).ToList();

            //var Calculo = ListaVenda.GroupBy(x => new { ProdutoAgrupado = x.Produto }) // new novo objeto ProdutoAgrupado agrupo todos os produtos repetidos
            //    .Select(s => new Vendas 
            //    { 
            //      Produto = s.Key.ProdutoAgrupado, // acesso todos os prpdutos agrupados
            //      quantidade=s.Sum(x=>Convert.ToInt32(x.quantidade)).ToString(), //soma de todas quantidades por produto agrupado
            //      ValorTotal = s.Sum(x=>x.ValorTotal) //soma de valor total por produto agrupado
            //    }).ToList(); 

            return View();
        }
        
        [HttpGet]
        public IActionResult Addcarrinho()
        {
            var IdUsuario = Convert.ToInt32(GetUsuarioCashId());
            var x = pedidooRepository.GetByIidUsuarioPedidoAberto(IdUsuario).Select(s=>s.Itens).FirstOrDefault();            
            return Json(x.Count());
        }

        [HttpPost]
        public IActionResult Addcarrinho([FromBody]int IdProduto )
        {
            var IdUsuario = Convert.ToInt32(GetUsuarioCashId());

            var ListaVenda = pedidooRepository.GetByIidUsuarioPedidoAberto(IdUsuario);

            var novoitem = new ItemPedido();
           
            novoitem.Produto = produtoRepository.BuscaporId(IdProduto);
            novoitem.quantidade = 1.ToString();
            
            if (!ListaVenda.Any())
            {
                var novoPedido = new Pedido();

                novoPedido.Usuario = usuarioRepository.BuscarUsuarioporId(IdUsuario);
                novoPedido.Status = statuspedidoRepository.BuscarDescricaoporid(1);
                novoPedido.ValorTotal = Convert.ToUInt32(novoitem.quantidade) * novoitem.Produto.Preco;
                pedidooRepository.SalvarVenda(novoPedido);

                novoitem.Pedido = novoPedido;

                itemPedidoRepository.SalvarItem(novoitem);

            }
            else if (ListaVenda[0].Itens.Where(x=>x.Produto==novoitem.Produto).Count()>0)
            {
                var itemexistente = ListaVenda[0].Itens.Where(x => x.Produto == novoitem.Produto).FirstOrDefault();
                var qtd = Convert.ToInt32(itemexistente.quantidade);
                itemexistente.quantidade = (qtd+1).ToString();
                ListaVenda[0].ValorTotal = ListaVenda[0].Itens.Sum(s => Convert.ToInt32(s.quantidade) * s.Produto.Preco);
                itemPedidoRepository.SalvarItem(itemexistente);
                pedidooRepository.SalvarVenda(ListaVenda[0]);
                //ListaVenda = pedidooRepository.GetByIidUsuarioPedidoAberto(IdUsuario);
            }
            else
            {
                novoitem.Pedido = ListaVenda[0];
                itemPedidoRepository.SalvarItem(novoitem);
                ListaVenda[0].Itens.Add(novoitem);
                ListaVenda[0].ValorTotal = ListaVenda[0].Itens.Sum(s => Convert.ToInt32(s.quantidade) * s.Produto.Preco);
                pedidooRepository.SalvarVenda(ListaVenda[0]);
                
            }

            //var calculo = ListaVenda.GroupBy(x => new { idProduto = x.Id })
            //    .Select(s => new Vendas { Produto = s.Key.idProduto}).ToList();

            //var Calculo = ListaVenda.GroupBy(x => new { ProdutoAgrupado = x.Produto }) // new novo objeto ProdutoAgrupado agrupo todos os produtos repetidos
            //    .Select(s => new Vendas 
            //    { 
            //      Produto = s.Key.ProdutoAgrupado, // acesso todos os prpdutos agrupados
            //      quantidade=s.Sum(x=>Convert.ToInt32(x.quantidade)).ToString(), //soma de todas quantidades por produto agrupado
            //      ValorTotal = s.Sum(x=>x.ValorTotal) //soma de valor total por produto agrupado
            //    }).ToList(); 

            return Json(new CarrinhoViewModel(ListaVenda[0].Itens.Count().ToString(),true));
        }

        public int? GetUsuarioCashId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("Id");
        }
    }
}