using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Application.Dtos
{
    public class UsuarioDto
    {
        public Guid Uuid { get; set; }

        public static UsuarioDto FromEntity(Usuario usuario)
        {
            return new UsuarioDto
            {
                Uuid = usuario.Uuid
            };
        }

        public static Usuario ToEntity(UsuarioDto usuarioDto)
        {
            return new Usuario(usuarioDto.Uuid);
        }
    }
}
