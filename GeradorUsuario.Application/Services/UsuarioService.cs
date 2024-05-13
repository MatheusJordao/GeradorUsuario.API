using GeradorUsuario.Application.Interfaces;
using GeradorUsuario.Domain.DTOs;
using GeradorUsuario.Domain.Entidades;
using GeradorUsuario.Domain.Interfaces;

namespace GeradorUsuario.Application.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository, IRandomRepository randomUserRepository) : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IRandomRepository _randomUserRepository = randomUserRepository;
        
        public async Task<UsuarioOutputDto?> GetById(Guid uuid)
        {
            Usuario? usuarioDb = await _usuarioRepository.GetByIdAsync(uuid);

            if (usuarioDb == null)
            {
                return null;
            }
            return UsuarioOutputDto.FromEntity(usuarioDb);
        }
        public async Task<UsuarioOutputDto> Add(UsuarioInputDto usuarioDto)
        {
            // Verifica se o email já existe
            if (await _usuarioRepository.ExistsByEmail(usuarioDto.Email))
            {
                throw new ArgumentException("Já existe um usuário com esse endereço de email.");
            }

            Usuario usuarioCreate = UsuarioInputDto.ToEntity(usuarioDto);
            await _usuarioRepository.AddAsync(usuarioCreate);
            return UsuarioOutputDto.FromEntity(usuarioCreate);
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

        public async Task<IEnumerable<UsuarioOutputDto>?> GetAll()
        {
            List<Usuario> usuarioDb = await _usuarioRepository.GetAllAsync();
            return usuarioDb.Select(UsuarioOutputDto.FromEntity).ToList();
        }

        public async Task<UsuarioOutputDto?> Update(Guid uuid, UsuarioInputDto usuarioDto)
        {
            var usuarioDb = await _usuarioRepository.GetByIdAsync(uuid);
            if (usuarioDb == null)
            {
                throw new Exception("Usuário não localizado");
            }

            //Validar se o email já existe somente quando o email for diferente do atual
            if (usuarioDto.Email != usuarioDb.Email && await _usuarioRepository.ExistsByEmail(usuarioDto.Email))
            {
                throw new ArgumentException("Já existe um usuário com esse endereço de email.");
            }

            usuarioDb.Update(usuarioDto.NomeUsuario, usuarioDto.Email, usuarioDto.Senha);
            await _usuarioRepository.SaveChangesAsync();
            return UsuarioOutputDto.FromEntity(usuarioDb);
        }

        public async Task<UsuarioOutputDto> AddUsuarioAleatorio()
        {
            var usuarioDto = await _randomUserRepository.CreateRandomUser();

            if (usuarioDto == null)
            {
                throw new Exception("Ocorreu um erro na geração aleatória de usuário.");
            }

            // Verifica se o email já existe
            if (await _usuarioRepository.ExistsByEmail(usuarioDto.Email))
            {
                throw new ArgumentException("Já existe um usuário com esse endereço de email.");
            }

            Usuario usuarioCreate = UsuarioInputDto.ToEntity(usuarioDto);
            await _usuarioRepository.AddAsync(usuarioCreate);
            return UsuarioOutputDto.FromEntity(usuarioCreate);
        }
    }
}
