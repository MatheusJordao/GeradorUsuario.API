using GeradorUsuario.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GeradorUsuario.Infra.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
