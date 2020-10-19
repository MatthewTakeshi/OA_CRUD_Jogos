using Desafio_CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace Desafio_CRUD.Server
{
     public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JogoGenero>().HasKey(t => new {t.JogoID, t.GeneroID});

            modelBuilder.Entity<JogoGenero>().HasOne(pt => pt.Jogo).WithMany(p => p.JogoGeneros)
            .HasForeignKey(pt => pt.JogoID);

            modelBuilder.Entity<JogoGenero>().HasOne(pt => pt.Genero).WithMany(t => t.JogoGeneros)
            .HasForeignKey(pt => pt.GeneroID);
        }
    }
}