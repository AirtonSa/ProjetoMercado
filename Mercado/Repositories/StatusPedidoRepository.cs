using Mercado.Banco;
using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public class StatusPedidoRepository : BaseRepository<StatusPedido>, IStatusPedidoRepository
    {

        public StatusPedidoRepository(AplicationContext context) : base(context)
        {

        }

        public StatusPedido BuscarDescricaoporid( int id)
        {
            var buscardescrição = dbSet

                .Where(d => d.Id == id).FirstOrDefault();

            return buscardescrição;



        }
    }
}
