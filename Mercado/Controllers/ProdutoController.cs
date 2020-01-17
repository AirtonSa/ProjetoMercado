using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.Models;
using Mercado.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Controllers
{
   

    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            var Lista = produtoRepository.BuscarListaDeProduto();


            return View(Lista);
        }

        public IActionResult CadastrarProduto()
        {
            

            return View();
        }

        public IActionResult ConfirmarCadastro(ProdutoViewModel produto)
        {

            if (produto.Nome != null && produto.Preco != null)
            {
                var produtoinsert = new Produto();

                produtoinsert.Preco = Convert.ToDecimal(produto.Preco);
                produtoinsert.Nome = produto.Nome;

                var produtoencontrado = produtoRepository.ExisteProduto(produtoinsert);

                if (produtoencontrado)
                {
                    var msg = "Produto é Existente";
                    @ViewBag.msg = msg;
                }
                else
                {
                    produtoRepository.SalvarProduto(produtoinsert);
                    var msg = "Produto Cadastrado";
                    @ViewBag.msg = msg;

                }     

               

                 
            }
            else
            {
                if (produto.Nome == null)
                {
                    var msg = "Campo Nome não pode ser vazio";
                    @ViewBag.msg = msg;
                }
                else if (produto.Preco == null)
                {
                  var msg = "Campo preço não pode ser vazio";
                  @ViewBag.msg = msg;

                    

                       
                }
            }

            return View();

        }

        [HttpPost]
        public IActionResult ProdutoAjax([FromBody]string produto)//[FromBody]
        {

            var pro = produtoRepository.RetornaProduto(produto);

            return Json(pro);
        }
        //Aqui Vai o metodo ajax

            

        

        



       

       
    }
}