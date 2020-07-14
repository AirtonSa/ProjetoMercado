using Mercado.Banco;
using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        
        public ItemPedidoRepository(AplicationContext context) : base(context)
        {

        }
        public void SalvarItem(ItemPedido Item)
        {
            if( Item.Id > 0 ){

                dbSet.Update(Item);
                context.SaveChanges();

            }else
            {
                dbSet.Add(Item);
                context.SaveChanges();

            }

        }

      

         
    }
}
