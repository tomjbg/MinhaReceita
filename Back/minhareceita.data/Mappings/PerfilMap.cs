using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using minhareceita.domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace minhareceita.data.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Username).HasColumnType("varchar(100)").IsRequired();
            builder.Property(m => m.DataNascimento).HasColumnType("datetime2");
            builder.Property(m => m.DataInscricao).HasColumnType("datetime2");
            builder.Property(m => m.Foto).HasColumnType("text");

            builder.HasMany(m => m.Comentarios)
                .WithOne(m => m.Perfil)
                .HasForeignKey(m => m.PerfilId);

        }
    }
}
