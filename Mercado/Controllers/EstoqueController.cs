using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.Models;
using Mercado.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IEstoqueRepository estoqueRepository;
        private readonly IProdutoRepository produtoRepository;
        private readonly IUsuarioRepository usuarioRepository;
        public EstoqueController(IEstoqueRepository estoqueRepository, IProdutoRepository produtoRepository, IUsuarioRepository usuarioRepository)
        {
            this.produtoRepository = produtoRepository;
            this.estoqueRepository = estoqueRepository;
            this.usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {

            var lista = produtoRepository.BuscarListaDeProduto();
            return View(lista);

        }

        [HttpPost]
        public IActionResult CadastrarEstoque([FromBody] Estoque Estoque)
        {

            var x = estoqueRepository.BuscarPorID(1);

            if (Estoque.Quantidade != 0 && Estoque.Produto.Id != 0)
            {
                //var Estoqueenc = 0;//estoqueRepository.ExisteProdutonoEstoque(estoque);

                Estoque.Produto = produtoRepository.BuscaporId(Estoque.Produto.Id);
                Estoque.Usuario = usuarioRepository.PorId(1);

                //var antesdesalvar = estoqueRepository.PorProduto(Estoque.Produto);
                var buscar_Produto_por_Id = estoqueRepository.BuscarPorIdDoPRoduto(Estoque.Produto.Id);
                //estoqueRepository.SalvarEstoque(Estoque);

                var depoissalvar = estoqueRepository.PorProduto(Estoque.Produto);

                if (1 == 1)
                {
                    var lista = estoqueRepository.BuscarListaEstoque();
                    //var msg = "Já existe no estoque";
                    //@ViewBag.msg = msg;
                }
                //else
                //{
                //    //estoqueRepository.SalvarEstoque(estoque);
                //    //var msg = "Salvo no estoque";
                //    //@ViewBag.msg = msg;
                //}

                //var msg = "Produto adicionado no estoque";
                //@ViewBag.msg = msg;





                return Json("True");
                



            }
            else
            {
                return Json("false");
            }

            
        }
    }
}
