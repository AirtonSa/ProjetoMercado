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

        public VendasController(IVendasRepository vendasRepository, IProdutoRepository produtoRepository, IEstoqueRepository estoqueRepository, IUsuarioRepository usuarioRepository)
        {
            this.vendasRepository = vendasRepository;
            this.produtoRepository = produtoRepository;
            this.estoqueRepository = estoqueRepository;
            this.usuarioRepository = usuarioRepository;
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

            for(var i = 0; i <listaViewModel.Count(); i++)
            {
                var venda = new Vendas();

                venda.Produto = produtoRepository.BuscaporId(Convert.ToInt32(listaViewModel[i].idProduto));
                venda.Usuario = usuarioRepository.BuscarUsuarioporId(1);
                venda.quantidade = listaViewModel[i].quantidade;
                venda.ValorTotal = listaViewModel[i].ValorTotal;
                listaDeVenda.Add(venda);
                
            }
            for(var i = 0; i < listaDeVenda.Count(); i++)
            {
                var venda = listaDeVenda[i].Id;

                vendasRepository.SalvarVenda(listaDeVenda[i]);
                //vendasRepository.SalvarVenda();

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

            foreach(var i in listaViewModel)
            {
                var venda = new Vendas();

                venda.Produto = produtoRepository.BuscaporId(Convert.ToInt32(i.idProduto));
                venda.quantidade = i.quantidade;
                venda.Usuario = usuarioRepository.BuscarUsuarioporId(1);
                venda.ValorTotal = i.ValorTotal;

                lista.Add(venda);
            }

            foreach(var i in lista)
            {
                //vendasRepository.SalvarVenda(i);
                
            }

            var msg = "";

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

            #region listalin1

            var listas = new List<Vendas>(); //3
                                             // para i é varialiicial , i<tamanhoarraylista, i = incremento em +1
            for (int i = 0; i < listaViewModel.Count(); i++)
            {
                var venda = new Vendas();
                
                venda.Produto = produtoRepository.BuscaporId(Convert.ToInt32(listaViewModel[i].idProduto)); //acesso a posição de cada passagem no i f11
                venda.quantidade = listaViewModel[i].quantidade;
                venda.ValorTotal = listaViewModel[i].ValorTotal;
                venda.Usuario = usuarioRepository.BuscarUsuarioporId(1);
                listas.Add(venda); //adiciono na lista 

            }

            for (int posicaoinicial = 0; posicaoinicial < listas.Count(); posicaoinicial++)
            {
                

                var Venda = listas[posicaoinicial];
                         
               // vendasRepository.SalvarVenda(Venda);

            }

            #endregion

            //var Est = produtoRepository.RetornaProduto(listaViewModel);

            return Json(msgRetorno);
        }

        public IActionResult RetornarVenda()
        {
            var ListaVenda = vendasRepository.BuscarListaVenda();

            return View(ListaVenda);
        }
    }
}