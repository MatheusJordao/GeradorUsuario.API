using GeradorUsuario.Application.Dtos;
using GeradorUsuario.Application.Interfaces;
using GeradorUsuario.Domain.Entidades;
using GeradorUsuario.Domain.Interfaces;

namespace GeradorUsuario.Application.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<UsuarioDto?> GetById(Guid uuid)
        {
            Usuario usuarioDb = await _usuarioRepository.GetByIdAsync(uuid);
            return UsuarioDto.FromEntity(usuarioDb);
        }
        public async Task<UsuarioDto> Add(UsuarioDto itemDto)
        {
            Usuario usuarioCreate = UsuarioDto.ToEntity(itemDto);
            await _usuarioRepository.AddAsync(usuarioCreate);
            return itemDto;
        }

        public async Task<bool> Delete(Guid uuid)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(uuid);
            if (usuario == null)
            {
                return false;
            }

            await _usuarioRepository.Delete(usuario.Uuid);
            return true;
        }

        public async Task<IEnumerable<UsuarioDto>?> GetAll()
        {
            List<Usuario> usuarioDb = await _usuarioRepository.GetAllAsync();
            return usuarioDb.Select(UsuarioDto.FromEntity).ToList();
        }

        public async Task<UsuarioDto?> Update(Guid uuid, UsuarioDto itemDto)
        {
            var usuarioDb = await _usuarioRepository.GetByIdAsync(uuid);
            if (usuarioDb == null)
            {
                throw new Exception("Usuário não localizado");
            }

            usuarioDb.Update();
            await _usuarioRepository.SaveChangesAsync();
            return UsuarioDto.FromEntity(usuarioDb);
        }
    }
}
