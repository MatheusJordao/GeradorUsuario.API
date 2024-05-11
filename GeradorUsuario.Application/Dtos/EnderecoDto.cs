using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Application.Dtos
{
    public class EnderecoDto
    {
        public Guid Uuid { get; private set; }
        public Guid UsuarioID { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string ZipCode { get; private set; }

        public static EnderecoDto FromEntity(Endereco endereco)
        {
            return new EnderecoDto
            {
                Uuid = endereco.Uuid,
                UsuarioID = endereco.UsuarioID,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                Pais = endereco.Pais,
                ZipCode = endereco.ZipCode
            };
        }

        public Endereco ToEntity()
        {
            return new Endereco(UsuarioID, Logradouro, Numero, Cidade, Estado, Pais, ZipCode);
        }
    }
}
