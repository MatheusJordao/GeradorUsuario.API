using GeradorUsuario.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GeradorUsuario.Infra.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasData(new Usuario("João", "joao@email.com", "1234"),
                         new Usuario("Maria", "maria@email.com", "5678"),
                         new Usuario("José", "jose@email.com", "1234"),
                         new Usuario("Ana", "Ana@email.com", "5678"),
                         new Usuario("Pedro", "pedro@email.com", "1234"),
                         new Usuario("Paula", "paula@email.com", "5678"),
                         new Usuario("Carlos", "carlos@email.com", "1234"),
                         new Usuario("Mariana", "mariana@email.com", "5678"),
                         new Usuario("Lucas", "lucas@email.com", "1234"),
                         new Usuario("Juliana", "juliana@email.com", "5678"));
        }
    }
}
