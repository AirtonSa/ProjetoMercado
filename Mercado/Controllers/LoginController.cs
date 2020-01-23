using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.Models;
using Mercado.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Acessar(Usuario usuario)
        {

            if (usuario.Nome != null && usuario.Senha != null)
            {
                var usuarionome = usuarioRepository.ExisteUsuario(usuario);

                if (usuarionome)
                {
                    return View();
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
    }
}