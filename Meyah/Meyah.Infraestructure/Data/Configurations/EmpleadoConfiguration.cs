using Meyah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Infraestructure.Data.Configurations
{
    class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");

            builder.Property(e => e.Apellidoem)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Creado).HasColumnType("date");

            builder.Property(e => e.Modificado).HasColumnType("date");

            builder.Property(e => e.Nombreemp)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Empleados)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__Usuari__2C3393D0");
        }
    }
}
