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
                estoqueRepository.SalvarEstoque(Estoque);

                //var depoissalvar = estoqueRepository.PorProduto(Estoque.Produto);

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





                return Json("msg"); //Quando  atualizar o estoque
                



            }
            else
            {
                return Json("msg"); //Quando der erro 
            }

            
        }
        [HttpPost]
        public IActionResult VerificaEstoqueProduto([FromBody] EstoqueViewModel EstoqueViewModel)
        {
            var viewmodelestoqueretorno = new EstoqueViewModel();

            var ListaEstoqueProdudo = estoqueRepository.GetByIdProduto(EstoqueViewModel.IdProduto);//IdProduto);

            if (ListaEstoqueProdudo.Count()>0)//a lista contem elemento
            {
                var somaestoque = ListaEstoqueProdudo.Sum(s => s.Quantidade);

                if (EstoqueViewModel.Quantidade <= somaestoque)
                {
                    viewmodelestoqueretorno.PossueEstoque = true;
                }
                else
                {
                    viewmodelestoqueretorno.Saldo = somaestoque;
                    viewmodelestoqueretorno.Mensagem = "Sem Estoque";
                    viewmodelestoqueretorno.PossueEstoque = false;
                }

                return Json(viewmodelestoqueretorno);

            }
            else
            {
                viewmodelestoqueretorno.Saldo = 0;
                viewmodelestoqueretorno.Mensagem = "Sem Estoque";
                viewmodelestoqueretorno.PossueEstoque = false;
                return Json(viewmodelestoqueretorno);
            }
            
        }
        [HttpPost]
        public IActionResult SalvarListaDeEstoque([FromBody] List<EstoqueViewModel> listaEstoqueViewModel)
        {

            var novalistaEstoque = new List<Estoque>();

            foreach (var i in listaEstoqueViewModel)
            {
                var estoque = new Estoque();
                estoque.Produto = produtoRepository.BuscaporId(i.IdProduto);
                estoque.Usuario = usuarioRepository.BuscarUsuarioporId(1);
                estoque.Quantidade = i.Quantidade;


                novalistaEstoque.Add(estoque);
            }
            
            for(var i = 0; i < novalistaEstoque.Count(); i++)
            {
                

                estoqueRepository.SalvarEstoque(novalistaEstoque[i]);

               
            }
            var msg = "";
            for(var i = 0; i < novalistaEstoque.Count(); i++)
            {
                if(novalistaEstoque[i].Id > 0)
                {

                    msg = "Estoque atualizado";

                }
                else
                {
                    msg = "Estoque não atualizado";
                }

            }

            return Json(msg);
        }
        
    }
}
