using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Domain.DTOs
{
    public class UsuarioOutputDto
    {
        public Guid Uuid { get; private set; }
        public string NomeUsuario { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public static UsuarioOutputDto FromEntity(Usuario usuario)
        {
            return new UsuarioOutputDto
            {
                Uuid = usuario.Uuid,
                Email = usuario.Email,
                NomeUsuario = usuario.NomeUsuario,
                Senha = usuario.Senha
            };
        }
    }
}
