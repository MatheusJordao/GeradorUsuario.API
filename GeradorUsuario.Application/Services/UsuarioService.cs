using GeradorUsuario.Application.Dtos;
using GeradorUsuario.Application.Interfaces;
using GeradorUsuario.Domain.Entidades;
using GeradorUsuario.Domain.Interfaces;

namespace GeradorUsuario.Application.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository) : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository = enderecoRepository;

        public async Task<UsuarioDto?> GetById(Guid uuid)
        {
            Usuario usuarioDb = await _usuarioRepository.GetByIdAsync(uuid);
            return UsuarioDto.FromEntity(usuarioDb);
        }
        public async Task<UsuarioDto> Add(UsuarioDto usuarioDto)
        {
            Usuario usuarioCreate = UsuarioDto.ToEntity(usuarioDto);
            await _usuarioRepository.AddAsync(usuarioCreate);
            return usuarioDto;
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

        public async Task<UsuarioDto?> Update(Guid uuid, UsuarioDto usuarioDto)
        {
            var usuarioDb = await _usuarioRepository.GetByIdAsync(uuid);
            if (usuarioDb == null)
            {
                throw new Exception("Usuário não localizado");
            }

            usuarioDb.Update(usuarioDto.PrimeiroNome, usuarioDto.UltimoNome, usuarioDto.Genero, usuarioDto.Email, usuarioDto.NomeUsuario, usuarioDto.SenhaSha256, usuarioDto.Telefone, usuarioDto.Celular, usuarioDto.Foto);
            await _usuarioRepository.SaveChangesAsync();
            return UsuarioDto.FromEntity(usuarioDb);
        }
    }
}
