using Meyah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Infraestructure.Data.Configurations
{
    class TareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.ToTable("Tarea");

            builder.Property(e => e.Creado).HasColumnType("date");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.FechaInicio).HasColumnType("date");

            builder.Property(e => e.Fechaentrega).HasColumnType("date");

            builder.Property(e => e.Modificado).HasColumnType("date");

            builder.HasOne(d => d.Empleado)
                .WithMany(p => p.Tareas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tarea__EmpleadoI__36B12243");

            builder.HasOne(d => d.Pedido)
                .WithMany(p => p.Tareas)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tarea__PedidoId__35BCFE0A");
        }
    }
}
