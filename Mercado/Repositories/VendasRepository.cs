using Mercado.Banco;
using Mercado.Models;
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
            //else
            //{
            //    dbSet.UpdateRange(lista);
            //    context.SaveChanges();

            //}

        }

    }
}
