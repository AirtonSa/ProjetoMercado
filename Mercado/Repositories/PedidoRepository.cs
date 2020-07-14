using Mercado.Banco;
using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AplicationContext context) : base(context)
        {

        }

        public void SalvarlistaVenda(List<Pedido> lista)
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
        public List<Pedido> BuscarListaVenda()
        {
            var lista = dbSet
                .Include(p => p.Usuario)
                .ToList();

            return lista;
        }

        public void SalvarVenda(Pedido venda)
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
        public List<Pedido> GetByIidUsuarioPedidoAberto(int idUsuario)
        {
            var lista = dbSet
                .Include(p => p.Usuario)
                //.Include(i=>i.Itens).ThenInclude(t=>((ItemPedido)t).Produto)
                .Include(i => i.Itens).ThenInclude(t => (t as ItemPedido).Produto)
                .Include(s=>s.Status)
                .Where(u => u.Usuario.Id == idUsuario && u.Status.Id==1)
                .OrderByDescending(o=>o.Id).ToList();

            return lista;

        }

    }
}
