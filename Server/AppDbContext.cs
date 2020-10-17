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

        public DbSet<Plataforma> teste { get; set; }
    }
}