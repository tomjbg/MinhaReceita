using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minhareceita.data.Mappings;
using minhareceita.domain.Models;

namespace minhareceita.data.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<ModoPreparoEtapa> ModosPreparoEtapas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder?.ApplyConfiguration<Perfil>(new PerfilMap());
            modelBuilder?.ApplyConfiguration<Receita>(new ReceitaMap());
            modelBuilder?.ApplyConfiguration<Comentario>(new ComentarioMap());
            modelBuilder?.ApplyConfiguration<ModoPreparoEtapa>(new ModoPreparoEtapaMap());
            modelBuilder?.ApplyConfiguration<Categoria>(new CategoriaMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
