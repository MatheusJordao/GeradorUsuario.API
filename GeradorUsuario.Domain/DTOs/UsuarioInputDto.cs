using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Domain.DTOs
{
    public class UsuarioInputDto(string nomeUsuario, string email, string senha)
    {
        public string NomeUsuario { get; set; } = nomeUsuario;
        public string Email { get; set; } = email;
        public string Senha { get; set; } = senha;

        public static Usuario ToEntity(UsuarioInputDto usuarioDto)
        {
            return new Usuario(usuarioDto.NomeUsuario, usuarioDto.Email, usuarioDto.Senha);
        }
    }
}
