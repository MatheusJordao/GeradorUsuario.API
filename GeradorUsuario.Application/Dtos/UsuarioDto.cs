using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Application.Dtos
{
    public class UsuarioDto
    {
        public Guid Uuid { get; set; }
        public string Titulo { get; private set; }
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Genero { get; private set; }
        public string Email { get; private set; }
        public string NomeUsuario { get; private set; }
        public string SenhaSha256 { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public string Foto { get; private set; }
        public EnderecoDto? EnderecoDto { get; private set; }

        public static UsuarioDto FromEntity(Usuario usuario)
        {
            return new UsuarioDto
            {
                Uuid = usuario.Uuid,
                Titulo = usuario.Titulo,
                PrimeiroNome = usuario.PrimeiroNome,
                UltimoNome = usuario.UltimoNome,
                Genero = usuario.Genero,
                Email = usuario.Email,
                NomeUsuario = usuario.NomeUsuario,
                SenhaSha256 = usuario.SenhaSha256,
                Telefone = usuario.Telefone,
                Celular = usuario.Celular,
                Foto = usuario.Foto,
                EnderecoDto = usuario.Endereco != null ? EnderecoDto.FromEntity(usuario.Endereco) : null
            };
        }

        public static Usuario ToEntity(UsuarioDto usuarioDto)
        {
            return new Usuario(usuarioDto.Titulo, usuarioDto.PrimeiroNome, usuarioDto.UltimoNome, usuarioDto.Genero, usuarioDto.Email, usuarioDto.NomeUsuario, usuarioDto.SenhaSha256, usuarioDto.Telefone, usuarioDto.Celular, usuarioDto.Foto);
        }
    }
}
