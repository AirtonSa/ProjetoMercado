using Mercado.Banco;
using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AplicationContext context) : base(context)
        {

        }

        public void SalvarUsuario(Usuario usuario)
        {
           

            if (usuario.Id > 0)
            {
                dbSet.Update(usuario);
                context.SaveChanges();
            }
            else
            {
                dbSet.Add(usuario);
                context.SaveChanges();
            }

        }

        public Usuario PorId(int id)
        {
            try
            {
                var usuario = dbSet.Where(x => x.Id == id).FirstOrDefault();

                return usuario;
            }
            catch(Exception e)
            {
                return new Usuario();
            }
           

        }

        public Usuario PorNome(Usuario usuario ) //essa é outa forma de ver se o usuario é existente
        {
                var usuarioencon = dbSet.Where(x => x.Nome == usuario.Nome && x.Senha ==  usuario.Senha).FirstOrDefault();
                
                if(usuarioencon != null)
                {
                    return usuarioencon;
                }
                else
                {
                    return usuarioencon;
                }
        }

        public bool ExisteUsuario(Usuario usuario) //varifica se o usuario é existente  (verdadeiro ou falso)
        {
            var usuarioencon = dbSet.Where(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha).FirstOrDefault();

            if (usuarioencon == null)
            {
                return false; //não existe
            }
            else
            {
                return true; //existe
            }
            
        }

        
        
    }
}
