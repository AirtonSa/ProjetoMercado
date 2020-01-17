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
        public VendasController(IVendasRepository vendasRepository, IProdutoRepository produtoRepository)
        {
            this.vendasRepository = vendasRepository;
            this.produtoRepository = produtoRepository;
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

            var lista_venda_linq = listaViewModel.Select(v => new Vendas
            {
                Produto = produtoRepository.BuscaporId(Convert.ToInt32(v.idProduto)),
                quantidade = v.quantidade,
                ValorTotal = v.ValorTotal
            }).ToList();


            //foreach e o for 

            var lista = new List<Vendas>(); //3
        // para i é varialiicial , i<tamanhoarraylista, i = incremento em +1
            for (int i =0 ; i< listaViewModel.Count(); i++)
            {
                var venda = new Vendas();

                venda.Produto = produtoRepository.BuscaporId(Convert.ToInt32(listaViewModel[i].idProduto)); //acesso a posição de cada passagem no i f11
                //venda.quantidade = Convert.ToInt32(listaViewModel[i].quantidade);
                venda.ValorTotal = listaViewModel[i].ValorTotal;
                lista.Add(venda); //adiciono na lista 

            }

            var x = 0;
            foreach (var i in listaViewModel)
            {
                var venda = new Vendas();
                venda.Produto = produtoRepository.BuscaporId(Convert.ToInt32(i.idProduto));
                
                //venda.quantidade = Convert.ToInt32(i.quantidade);

                lista.Add(venda);
            }

            //var Est = produtoRepository.RetornaProduto(listaViewModel);

            return View();
        }
        


    }
}