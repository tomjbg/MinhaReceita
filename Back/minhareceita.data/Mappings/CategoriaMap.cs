using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhareceita.domain.Models;

namespace minhareceita.data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Descricao).HasColumnType("varchar(130)").IsRequired();

        }
    }
}
