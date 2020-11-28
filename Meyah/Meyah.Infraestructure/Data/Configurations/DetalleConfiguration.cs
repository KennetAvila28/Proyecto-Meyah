using System;
using System.Collections.Generic;
using System.Text;
using Meyah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meyah.Infraestructure.Data.Configurations
{
    public class DetalleConfiguration : IEntityTypeConfiguration<Detalle>
    {
        public void Configure(EntityTypeBuilder<Detalle> builder)
        {
            builder.ToTable("Detalle");

            builder.Property(e => e.Comentario)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Creado).HasColumnType("date");

            builder.Property(e => e.Fotografia).HasColumnType("image");

            builder.HasOne(d => d.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle__PedidoI__5AEE82B9");
        }
    }
}
