using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(Guid uuid);
        Task AddAsync(Usuario usuario);
        Task Delete(Guid uuid);
        Task<bool> ExistsByEmail(string email);
        Task SaveChangesAsync();
    }
}
