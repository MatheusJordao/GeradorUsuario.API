using GeradorUsuario.Domain.DTOs;

namespace GeradorUsuario.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto?> GetById(Guid uuid);
        Task<IEnumerable<UsuarioOutputDto>?> GetAll();
        Task<UsuarioOutputDto> Add(UsuarioInputDto itemDto);
        Task<UsuarioOutputDto> AddUsuarioAleatorio();
        Task<UsuarioOutputDto?> Update(Guid uuid, UsuarioInputDto itemDto);
        Task<bool> Delete(Guid uuid);
    }
}
