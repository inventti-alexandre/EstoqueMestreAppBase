using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Models.MappingConfiguration
{
    //public class ClienteMap : EntityTypeConfiguration<Cliente>
    //{
    //    public ClienteMap()
    //    {
    //        //Primary Key
    //        this.HasKey(t => t.Id);

    //        //Properties
    //        this.Property(t => t.Placa)
    //            .HasMaxLength(7);

    //        this.Property(t => t.Modelo)
    //            .HasMaxLength(20);

    //        this.Property(t => t.Chassis)
    //            .HasMaxLength(12);

    //        this.Property(t => t.Renavam)
    //            .HasMaxLength(12);

    //        this.Property(t => t.Ano)
    //            .HasMaxLength(9);

    //        this.Property(t => t.Cor)
    //            .HasMaxLength(20);

    //        //Table & Column Mappings
    //        this.ToTable("Veiculo");
    //        this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    //        this.Property(t => t.Placa).HasColumnName("Placa");
    //        this.Property(t => t.Modelo).HasColumnName("Modelo");
    //        this.Property(t => t.Chassis).HasColumnName("Chassis");
    //        this.Property(t => t.Renavam).HasColumnName("Renavam");
    //        this.Property(t => t.FlStatus).HasColumnName("FlStatus");
    //        this.Property(t => t.DtVencApolice).HasColumnName("DtVencApolice");
    //        this.Property(t => t.IdFrota).HasColumnName("IdFrota");
    //        this.Property(t => t.IdSeguradora).HasColumnName("IdSeguradora");
    //        this.Property(t => t.Cor).HasColumnName("Cor");
    //        this.Property(t => t.Ano).HasColumnName("Ano");
    //        this.Property(t => t.CodSeguranca).HasColumnName("CodSeguranca");
    //        this.Property(t => t.Quilometragem).HasColumnName("Quilometragem");
    //        this.Property(t => t.Quilometragem).HasColumnName("Quilometragem");
    //        this.Property(t => t.TipoPlaca).HasColumnName("TipoPlaca");
    //        this.Property(t => t.Franquia).HasColumnName("Franquia");
    //        this.Property(t => t.PremioLiquido).HasColumnName("PremioLiquido");
    //        this.Property(t => t.FlTipoApolice).HasColumnName("FlTipoApolice");
    //        this.Property(t => t.FlCategoria).HasColumnName("FlCategoria");
    //        this.Property(t => t.Deleted).HasColumnName("Deleted");

    //        //Relationships
    //        this.HasOptional(veiculo => veiculo.Seguradora)
    //            .WithMany(seguradora => seguradora.Veiculos)
    //            .HasForeignKey(veiculo => veiculo.IdSeguradora);

    //        this.HasOptional(veiculo => veiculo.Frota)
    //            .WithMany(frota => frota.Veiculos)
    //            .HasForeignKey(veiculo => veiculo.IdFrota);

    //        //1:0/1 relationships
    //        this.HasOptional(veiculo => veiculo.TpEscolar)
    //            .WithRequired(escolar => escolar.Veiculo)
    //            .WillCascadeOnDelete(true);

    //        this.HasOptional(veiculo => veiculo.TpPassageiro)
    //            .WithRequired(passageiro => passageiro.Veiculo)
    //            .WillCascadeOnDelete(true);

    //        this.HasOptional(veiculo => veiculo.TpCarga)
    //            .WithRequired(carga => carga.Veiculo)
    //            .WillCascadeOnDelete(true);
    //    }
    //}
}
