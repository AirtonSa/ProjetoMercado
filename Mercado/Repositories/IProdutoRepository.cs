using Mercado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{
    public interface IProdutoRepository 
    {
        public void SalvarProduto(Produto produto);

        public List<Produto> BuscarListaDeProduto();

        public bool ExisteProduto(Produto produto);

        public List<Produto> RetornaProduto(string produto);
        public Produto BuscaporId(int id);
    }
}
