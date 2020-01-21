using Mercado.Banco;
using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public class VendasRepository : BaseRepository<Vendas>, IVendasRepository
    {
        public VendasRepository(AplicationContext context) : base(context)
        {

        }

        public void SalvarlistaVenda(List<Vendas> lista)
        {

            if (lista.Count() > 0)
            {
                dbSet.AddRange(lista);
                context.SaveChanges();


            }
            else
            {
                dbSet.UpdateRange(lista);
                context.SaveChanges();

            }
        }
        public List<Vendas> BuscarListaVenda()
        {
            var lista = dbSet
                .Include(p => p.Produto)
                .ToList();

            return lista;
        }

        public void SalvarVenda(Vendas venda)
        {
            if (venda.Id == 0)
            {
                dbSet.Add(venda);
                context.SaveChanges();
            }
            else
            {
                dbSet.Update(venda);
                context.SaveChanges();
            }
        }
        public List<Vendas> GetByIidUsuario(int idUsuario)
        {
            var lista = dbSet
                .Include(p => p.Usuario)
                .Where(u => u.Usuario.Id == idUsuario).ToList();

            return lista;

        }

    }
}
