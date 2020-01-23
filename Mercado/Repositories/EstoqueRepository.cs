using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.Banco;
using Mercado.Models;
using Microsoft.EntityFrameworkCore;

namespace Mercado.Repositories
{
    public class EstoqueRepository : BaseRepository<Estoque>, IEstoqueRepository
    {
        //private readonly IProdutoRepository produtoRepository;

        public EstoqueRepository(AplicationContext context) : base(context)
        {
            //this.produtoRepository = produtoRepository;
        }
        public void SalvarEstoque(Estoque estoque)
        {
            if (estoque.Id > 0)
            {
                dbSet.Update(estoque);
                context.SaveChanges();
            }
            else
            {
                dbSet.Add(estoque);
                context.SaveChanges();
            }
        }
        public List<Estoque> BuscarListaEstoque()
        {

            var Listaestoque = dbSet.ToList();

            return Listaestoque;
        }

        public bool ExisteProdutonoEstoque(Estoque estoque)
        {
            var Estoqueencon = dbSet.Where(e => e.Quantidade == estoque.Quantidade && e.Produto == estoque.Produto).FirstOrDefault();

            if (estoque == null) {

                return false;
            }
            else
            {
                return true;
            }
         
        }

        public List<Estoque> listaEstoque()
        {
            var listaestoque = dbSet
                .Include(u => u.Usuario)
                .Include(p => p.Produto)
                .ToList();

           return listaestoque;
        }

        public Estoque PorProduto(Produto produto) //buscar ó produto pelo produto
        {
            var estoquedoproduto = dbSet
                .Include(p => p.Produto)
                .Where(p => p.Produto == produto).FirstOrDefault();

            return estoquedoproduto;
        }

        public Estoque BuscarPorIdDoPRoduto(int idproduto) //buscar o produto pelo ID
        {
            var produtoporid = dbSet
                .Include(p => p.Produto)
                .Where(p => p.Produto.Id == idproduto).FirstOrDefault();

            return produtoporid;
        }

        public Estoque BuscarPorID(int id )
        {
            var estoque = dbSet
                .Include(p=>p.Produto)
                .Where(i => i.Id == id).FirstOrDefault();

            return estoque;
                
        }

        public List<Estoque> GetByIdProduto(int idProduto)
        {
            var lista = dbSet
                .Include(p => p.Produto)
                .Where(i => i.Produto.Id == idProduto).ToList();

            return lista;

        }

        public Estoque BuscarEstoque(Produto produto)
        {
            var encontrar_Estoque = dbSet.Include(p=>p.Produto)
                .Where(e => e.Produto == produto).FirstOrDefault();

            if (encontrar_Estoque==null)
            {
                var vendavazia = new Estoque();
                
                return vendavazia;
            }
            else
            {
                return encontrar_Estoque;
            }
           
        }

        public void SalvarListaEstoque(List<Estoque> lista)
        {
            if(lista.Count() > 0)
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
        
        
        
    }

}
