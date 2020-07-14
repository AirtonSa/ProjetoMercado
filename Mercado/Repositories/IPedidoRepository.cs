using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public interface IPedidoRepository
    {
        public List<Pedido> BuscarListaVenda();

        public void SalvarlistaVenda(List<Pedido> lista);

        public void SalvarVenda(Pedido Pedido);

        List<Pedido> GetByIidUsuarioPedidoAberto(int idUsuario);
    }
}
