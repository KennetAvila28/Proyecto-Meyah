using Meyah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Infraestructure.Data.Configurations
{
    class TipoConfiguration : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.ToTable("Tipo");

            builder.Property(e => e.Nombretipo)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);
        }
    }
}
