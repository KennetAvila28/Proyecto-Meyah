using Meyah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Infraestructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.Property(e => e.Apellidocl)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Creado).HasColumnType("date");

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Modificado).HasColumnType("date");

            builder.Property(e => e.Nacimiento).HasColumnType("date");

            builder.Property(e => e.Nombrecl)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Clientes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__Usuario__29572725"); ;
        }

    }
}
