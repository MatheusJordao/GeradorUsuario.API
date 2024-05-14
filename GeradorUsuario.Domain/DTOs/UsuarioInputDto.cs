using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Domain.DTOs
{
    public class UsuarioInputDto
    {
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public static Usuario ToEntity(UsuarioInputDto usuarioDto)
        {
            return new Usuario(usuarioDto.NomeUsuario, usuarioDto.Email, usuarioDto.Senha);
        }
    }
}
