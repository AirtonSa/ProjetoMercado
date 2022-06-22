﻿// <auto-generated />
using System;
using Mercado.Banco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mercado.Migrations
{
    [DbContext(typeof(AplicationContext))]
    [Migration("20200116173314_modelo")]
    partial class modelo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mercado.Models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("Mercado.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Mercado.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Mercado.Models.Vendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("produtoId")
                        .HasColumnType("int");

                    b.Property<string>("quantidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("produtoId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Mercado.Models.Estoque", b =>
                {
                    b.HasOne("Mercado.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("Mercado.Models.Vendas", b =>
                {
                    b.HasOne("Mercado.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoId");

                    b.HasOne("Mercado.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}