using GeradorUsuario.Application.Dtos;

namespace GeradorUsuario.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto?> GetById(Guid uuid);
        Task<IEnumerable<UsuarioDto>?> GetAll();
        Task<UsuarioDto> Add(UsuarioDto itemDto);
        Task<UsuarioDto?> Update(Guid uuid, UsuarioDto itemDto);
        Task<bool> Delete(Guid uuid);
    }
}
