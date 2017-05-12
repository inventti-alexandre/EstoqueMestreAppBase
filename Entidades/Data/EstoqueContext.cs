using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entidades.Data
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Log> Log { get; set; }

        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente", "estoque");
            modelBuilder.Entity<Produto>().ToTable("Produto", "estoque");
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedor", "estoque");
            modelBuilder.Entity<Movimentacao>().ToTable("Movimentacao", "estoque");
            modelBuilder.Entity<Estoque>().ToTable("Estoque", "estoque");
            modelBuilder.Entity<Log>().ToTable("Log", "dbo");

            modelBuilder.Entity<Movimentacao>()
                .HasOne(p => p.Produto)
                .WithMany(b => b.Movimentacoes)
                .HasForeignKey(p => p.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Estoque>()
                .HasOne(p => p.Produto)
                .WithMany(b => b.Estoques)
                .HasForeignKey(p => p.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
