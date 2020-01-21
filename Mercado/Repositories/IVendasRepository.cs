using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public interface IVendasRepository
    {
        public List<Vendas> BuscarListaVenda();

        public void SalvarlistaVenda(List<Vendas> lista);

        public void SalvarVenda(Vendas venda);

     
    }
}
