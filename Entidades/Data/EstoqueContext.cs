﻿using Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Data
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }

        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedor");
            modelBuilder.Entity<Movimentacao>().ToTable("Movimentacao");
        }


    }
}
