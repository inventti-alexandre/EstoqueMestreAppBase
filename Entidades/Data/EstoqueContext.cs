using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Data
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

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
