using GeradorUsuario.Domain.DTOs;

namespace GeradorUsuario.Domain.Interfaces
{ 
    public interface IRandomRepository
    {
        public Task<UsuarioInputDto> CreateRandomUser();
    }
}
