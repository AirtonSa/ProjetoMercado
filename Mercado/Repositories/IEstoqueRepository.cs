using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public interface IEstoqueRepository 
    {
        public void SalvarEstoque(Estoque estoque);

        public List<Estoque> BuscarListaEstoque();

        public bool ExisteProdutonoEstoque(Estoque estoque);
        public Estoque PorProduto(Produto produto);

        //public Estoque BuscarPorIdDoPRoduto(int Id); 

        public Estoque BuscarPorIdDoPRoduto(int idproduto);

        public Estoque BuscarPorID(int id);

        public Estoque BuscarEstoque(Produto produto);

        public List<Estoque> GetByIdProduto(int idProduto);

        public void SalvarListaEstoque(List<Estoque> lista);



    }
}
