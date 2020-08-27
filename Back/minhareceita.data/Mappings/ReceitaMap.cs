using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhareceita.domain.Models;

namespace minhareceita.data.Mappings
{
    public class ReceitaMap : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("Receita");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(m => m.Video).HasColumnType("varchar(150)");
            builder.Property(m => m.Imagens).HasColumnType("text");
            builder.Property(m => m.Ingredientes).HasColumnType("text");

            builder.HasOne(m => m.Perfil)
                .WithMany(m => m.Receitas)
                .HasForeignKey(m => m.PerfilId);

            builder.HasMany(m => m.Comentarios)
                .WithOne(m => m.Receita)
                .HasForeignKey(m => m.ReceitaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.ModoPreparoEtapas)
                .WithOne(m => m.Receita)
                .HasForeignKey(m => m.ReceitaId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(m => m.Categoria)
                .WithOne(m => m.Receita)
                .HasForeignKey<Categoria>(m => m.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
