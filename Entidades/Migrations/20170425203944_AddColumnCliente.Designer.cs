using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Entidades.Data;

namespace Entidades.Migrations
{
    [DbContext(typeof(EstoqueContext))]
    [Migration("20170425203944_AddColumnCliente")]
    partial class AddColumnCliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Entidades.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<bool>("Deletado");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Sobrenome");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Entidades.Models.Fornecedor", b =>
                {
                    b.Property<int>("IdFornecedor")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Telefone")
                        .HasMaxLength(20);

                    b.HasKey("IdFornecedor");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("Entidades.Models.Movimentacao", b =>
                {
                    b.Property<int>("IdMovimentacao")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<bool>("Estornada");

                    b.Property<int>("IdCliente");

                    b.Property<int>("IdFornecedor");

                    b.Property<int>("IdProduto");

                    b.Property<string>("Observacao")
                        .HasMaxLength(150);

                    b.Property<decimal>("Quantidade");

                    b.Property<char>("TipoOperacao");

                    b.Property<decimal>("Valor");

                    b.HasKey("IdMovimentacao");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdFornecedor");

                    b.HasIndex("IdProduto");

                    b.ToTable("Movimentacao");
                });

            modelBuilder.Entity("Entidades.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .HasMaxLength(150);

                    b.Property<bool>("EstoqueBaixo");

                    b.Property<int>("IdFornecedor");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<decimal>("ValorCompra");

                    b.Property<decimal>("ValorVenda");

                    b.HasKey("IdProduto");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Entidades.Models.Movimentacao", b =>
                {
                    b.HasOne("Entidades.Models.Cliente", "Cliente")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entidades.Models.Fornecedor", "Fornecedor")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entidades.Models.Produto", "Produto")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("IdProduto");
                });

            modelBuilder.Entity("Entidades.Models.Produto", b =>
                {
                    b.HasOne("Entidades.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
