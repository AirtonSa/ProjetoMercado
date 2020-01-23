using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public interface IUsuarioRepository
    {
        public void SalvarUsuario(Usuario usuario);
        public Usuario PorId(int id);
        public Usuario PorNome(Usuario usuario);

        public bool ExisteUsuario(Usuario usuario);

        public Usuario BuscarUsuarioporId(int id);

        public bool UsuarioExiste(Usuario usuario);
    }
}
