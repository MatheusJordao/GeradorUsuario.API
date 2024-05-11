using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeradorUsuario.Domain.Entidades
{
    public class Endereco(Guid usuarioID, string logradouro, string numero, string cidade, string estado, string pais, string zipCode)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uuid { get; private set; } = Guid.NewGuid();
        public Guid UsuarioID { get; private set; } = usuarioID;
        public string Logradouro { get; private set; } = logradouro;
        public string Numero { get; private set; } = numero;
        public string Cidade { get; private set; } = cidade;
        public string Estado { get; private set; } = estado;
        public string Pais { get; private set; } = pais;
        public string ZipCode { get; private set; } = zipCode;


        public void Update(string logradouro, string numero, string cidade, string estado, string pais, string zipCode)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            ZipCode = zipCode;
        }
    }
}
