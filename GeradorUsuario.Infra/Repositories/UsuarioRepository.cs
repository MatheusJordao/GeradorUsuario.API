using GeradorUsuario.Domain.Entidades;
using GeradorUsuario.Domain.Interfaces;
using GeradorUsuario.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GeradorUsuario.Infra.Repositories
{
    public class UsuarioRepository(UserDbContext dbContext) : IUsuarioRepository
    {
        private readonly UserDbContext _dbContext = dbContext;

        public async Task AddAsync(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(Guid uuid)
        {
            return await _dbContext.Usuarios.SingleOrDefaultAsync(p => p.Uuid == uuid);
        }

        public async Task Delete(Guid uuid)
        {
            var usuario = await GetByIdAsync(uuid);
            _dbContext.Usuarios.Remove(usuario);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
