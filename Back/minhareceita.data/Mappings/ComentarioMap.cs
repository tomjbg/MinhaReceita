using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhareceita.domain.Models;

namespace minhareceita.data.Mappings
{
    public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Descricao).HasColumnType("varchar(150)");

        }
    }
}
