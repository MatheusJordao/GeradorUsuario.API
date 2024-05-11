using GeradorUsuario.Domain.Entidades;
using GeradorUsuario.Domain.Interfaces;
using GeradorUsuario.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GeradorUsuario.Infra.Persistence.Repositories
{
    public class EnderecoRepository(UserDbContext dbContext) : IEnderecoRepository
    {
        private readonly UserDbContext _dbContext = dbContext;

        public async Task AddAsync(Endereco endereco)
        {
            await _dbContext.Enderecos.AddAsync(endereco);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid uuid)
        {
            var endereco = await GetByUsuarioId(uuid);

            if (endereco != null)
            {
                _dbContext.Enderecos.Remove(endereco);
                await SaveChangesAsync();
            }
        }

        public async Task<Endereco?> GetById(Guid uuid)
        {
            return await _dbContext.Enderecos.SingleOrDefaultAsync(p => p.Uuid == uuid);
        }

        public async Task<Endereco?> GetByUsuarioId(Guid usuarioId)
        {
            return await _dbContext.Enderecos.SingleOrDefaultAsync(p => p.UsuarioID == usuarioId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
