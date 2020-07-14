using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Banco
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasKey(t => t.Id);

            modelBuilder.Entity<Produto>().HasKey(t => t.Id);
            modelBuilder.Entity<Produto>().Property(t => t.Preco).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Produto>().Property(t => t.Nome).HasColumnType("varchar(250)");
            //modelBuilder.Entity<Produto>().Property(t => t.Codigo).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            modelBuilder.Entity<Pedido>().Property(t => t.ValorTotal).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(w=>w.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(t => t.Usuario);
            modelBuilder.Entity<Pedido>().HasOne(t => t.Status);
            //modelBuilder.Entity<Vendas>().Property(t => t.ValorTotal).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);
            modelBuilder.Entity<ItemPedido>().Property(t => t.quantidade).HasColumnType("varchar(20)");
            //modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);

            modelBuilder.Entity<Estoque>().HasKey(t => t.Id);
            modelBuilder.Entity<Estoque>().HasOne(t => t.Produto);
            modelBuilder.Entity<Estoque>().HasOne(t => t.Usuario);
            modelBuilder.Entity<Estoque>().HasOne(t => t.TipoLancamento);

            modelBuilder.Entity<StatusPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<StatusPedido>().Property(t => t.Descricao).HasColumnType("varchar(50)");

            modelBuilder.Entity<TipoLancamento>().HasKey(t => t.Id);
            modelBuilder.Entity<TipoLancamento>().Property(t => t.Descricao).HasColumnType("varchar(50)");

            //modelBuilder.Entity<Usuario>().HasMany(t=>t.res)

            //modelBuilder.Entity<Veiculo>().HasKey(t => t.Id);



            //modelBuilder.Entity<Reserva>().HasKey(t => t.Id);
            //modelBuilder.Entity<Reserva>().HasOne(t => t.usuario);
            //modelBuilder.Entity<Reserva>().HasOne(t => t.Veiculo);


            //modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            //modelBuilder.Entity<Pedido>().HasOne(t => t.Reserva);
            //modelBuilder.Entity<Pedido>().HasOne(t => t.Status);

            //modelBuilder.Entity<StatusPedido>().HasKey(t => t.Id);
            ////modelBuilder.Entity<StatusPedido>().HasMany(t => t.Pedido);//.WithMany(t=>t.);

            //modelBuilder.Entity<Multa>().HasKey(t => t.Id);
            //modelBuilder.Entity<Multa>().HasOne(t => t.Usuario);
            //modelBuilder.Entity<Multa>().HasOne(t => t.Veiculo);

            //modelBuilder.Entity<Sinistro>().HasKey(t => t.Id);
            //modelBuilder.Entity<Sinistro>().HasOne(t => t.Usuario);
            //modelBuilder.Entity<Sinistro>().HasOne(t => t.Veiculo);

            //modelBuilder.Entity<Seguro>().HasKey(t => t.Id);
            //modelBuilder.Entity<Seguro>().HasOne(t => t.Usuario);
            //modelBuilder.Entity<Seguro>().HasOne(t => t.Veiculo);5

            //modelBuilder.Entity<EntradaSaidaVeiculo>().HasKey(t => t.Id);
            //modelBuilder.Entity<EntradaSaidaVeiculo>().HasOne(t => t.Usuario);
            //modelBuilder.Entity<EntradaSaidaVeiculo>().HasOne(t => t.Veiculo);
        }
    }
}
