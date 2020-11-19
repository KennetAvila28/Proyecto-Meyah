using Meyah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Infraestructure.Data.Configurations
{
    class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.Property(e => e.Cantidad).HasColumnName("cantidad");

            builder.Property(e => e.Estado).HasDefaultValueSql("((1))");

            builder.Property(e => e.Fechaentrega).HasColumnType("date");

            builder.Property(e => e.Fechapedido).HasColumnType("date");

            builder.Property(e => e.Modificado).HasColumnType("date");

            builder.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__ClienteI__32E0915F");

            builder.HasOne(d => d.Producto)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__Producto__31EC6D26");
        }
    }
}
