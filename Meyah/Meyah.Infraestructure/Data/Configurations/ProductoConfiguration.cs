using Meyah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Infraestructure.Data.Configurations
{
    class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");

            builder.Property(e => e.Nombreprod)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        }
    }
}
