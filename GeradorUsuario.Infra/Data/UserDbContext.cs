using GeradorUsuario.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GeradorUsuario.Infra.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
