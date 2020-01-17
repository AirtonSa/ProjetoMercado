using Mercado.Banco;
using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Repositories
{

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        
        public ProdutoRepository(AplicationContext context) : base(context)
        {

        }
        public void SalvarProduto(Produto produto)
        {
            if( produto.Id > 0 ){

                dbSet.Update(produto);
                context.SaveChanges();

            }else
            {
                dbSet.Add(produto);
                context.SaveChanges();

            }

        }

        public List<Produto> BuscarListaDeProduto()
        {
            var Listaproduto = dbSet.ToList();


            return Listaproduto;
        }

        public bool ExisteProduto(Produto produto)
        {
            var produtoenco = dbSet.Where(p => p.Nome == produto.Nome && p.Preco == produto.Preco).FirstOrDefault();

            if (produtoenco == null)
            {

                return false;
            }
            else
            {
                return true;
            }

           
        }


       public  List<Produto> RetornaProduto (string produto)
        {
            var produtoalgo = dbSet.Where(p => p.Nome.Contains(produto)).ToList();

            return produtoalgo;
        }
        //tipo retorno é produto
       /// recebr parametro de string (vem o nome do produto)
       /// //vai filtar no where pelo nome
       /// 
       public Produto BuscaporId(int id) //busca pelo ID //1
       {
            var produtoporid = dbSet.Where(p => p.Id == id).FirstOrDefault();
            if (1==1)
            {
                return produtoporid;
            }
       }

       //public Produto GetProduto()

         
    }
}
