using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhareceita.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace minhareceita.data.Mappings
{
    public class ModoPreparoEtapaMap : IEntityTypeConfiguration<ModoPreparoEtapa>
    {
        public void Configure(EntityTypeBuilder<ModoPreparoEtapa> builder)
        {
            builder.ToTable("ModoPreparoEtapa");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Etapa).IsRequired();
            builder.Property(m => m.Descricao).HasColumnType("varchar(150)").IsRequired();
        }
    }
}
