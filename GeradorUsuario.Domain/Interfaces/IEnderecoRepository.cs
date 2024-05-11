using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco?> GetById(Guid uuid);
        Task<Endereco?> GetByUsuarioId(Guid usuarioId);
        Task AddAsync(Endereco endereco);
        Task Delete(Guid uuid);
        Task SaveChangesAsync();
    }
}
