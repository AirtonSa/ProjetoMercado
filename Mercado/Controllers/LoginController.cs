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
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IProdutoRepository produtoRepository;
        public LoginController(IUsuarioRepository usuarioRepository, IHttpContextAccessor contextAccessor, IProdutoRepository produtoRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.contextAccessor = contextAccessor;
            this.produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

    
        public IActionResult Acessar(Usuario usuario)
        {

            if (usuario.Nome != null && usuario.Senha != null)
            {
                var iss = contextAccessor.HttpContext.Session.GetInt32("Id");

                var usuarionome = usuarioRepository.ExisteUsuario(usuario);

                var userencontrado = usuarioRepository.PorNome(usuario);
                if (usuarionome)
                {
                    contextAccessor.HttpContext.Session.SetInt32("Id", userencontrado.Id);
                    var teste = contextAccessor.HttpContext.Session.GetInt32("Id");
                    var listaproduto = new List<Produto>();

                    for (int i=0; i<7; i++)
                    {
                        listaproduto.AddRange(produtoRepository.BuscarListaDeProduto());
                    }
                    return View(listaproduto);
                }
                else
                {
                    return RedirectToAction("TesteDeError", "Home");
                }
            }
            else
            {
                return RedirectToAction("TesteDeError", "Home");
            }

        }

        public IActionResult CadastrarLogin() //view que leva para o usuario prenceher o seu cadastro
        {

            return View();

        }

        public IActionResult ConfirmarCadastro(Usuario usuario) //aqui vai a condição apos o usuario clicar no botão da view de cima
        {


            if (usuario.Nome != null && usuario.Senha != null)
            {
                var usuarioExiste = usuarioRepository.ExisteUsuario(usuario); //verifica se o usuario existe

                if (usuarioExiste)
                {
                    var msg = "usuario é Existente";
                    @ViewBag.msg = msg;
                }
                else
                {
                    usuarioRepository.SalvarUsuario(usuario); // criar método para salvar usuário

                    var msg = "usuario Salvo com sucesso";
                    @ViewBag.msg = msg;
                }

            }
            else
            {
                if (usuario.Nome == null)
                {
                    var msg = "O campo nome não pode ser vazio";
                    @ViewBag.msg = msg;
                }
                else if (usuario.Senha == null)
                {

                }


            }

            return View();
        }
        [HttpPost]
        public IActionResult JqueryAcessar([FromBody] Usuario usuario)
        {
            var novousuario = new Usuario();

            novousuario.Nome = usuario.Nome;
            novousuario.Senha = usuario.Senha;


            var msg = "";

            if (novousuario.Nome != null && novousuario.Senha != null)
            {


                var existe = usuarioRepository.UsuarioExiste(novousuario);

                if (existe)
                {
                    msg = "Usuario existente use esqueci minha senha";
                }
                else
                {
                    usuarioRepository.SalvarUsuario(novousuario);

                    msg = "Usuario Salvo";
                }

            }
            else
            {
                msg = "Usuario Nao salvo";
            }

            return Json(msg);
        }

        public int? GetUsuarioCashId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("Id");
        }

        public void SetUsuarioCashId(int IdUsuario)
        {
            contextAccessor.HttpContext.Session.SetInt32("Id", IdUsuario);
            //contextAccessor.HttpContext.Session.Set()

        }

        public void ClearCashId()
        {
            var id = contextAccessor.HttpContext.Session.GetInt32("Id");
            contextAccessor.HttpContext.Session.Clear();

            id = contextAccessor.HttpContext.Session.GetInt32("Id");

        }
    }
}