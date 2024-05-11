using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeradorUsuario.Domain.Entidades
{
    public class Usuario(string titulo, string primeiroNome, string ultimoNome, string genero, string email, string nomeUsuario, string senhaSha256, string telefone, string celular, string foto)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uuid { get; private set; } = Guid.NewGuid();
        public string Titulo { get; private set; } = titulo;
        public string PrimeiroNome { get; private set; } = primeiroNome;
        public string UltimoNome { get; private set; } = ultimoNome;
        public string Genero { get; private set; } = genero;
        public string Email { get; private set; } = email;
        public string NomeUsuario { get; private set; } = nomeUsuario;
        public string SenhaSha256 { get; private set; } = senhaSha256;
        public string Telefone { get; private set; } = telefone;
        public string Celular { get; private set; } = celular;
        public string Foto { get; private set; } = foto;

        public Endereco? Endereco { get; private set; }

        public void Update(string primeiroNome, string ultimoNome, string genero, string email, string nomeUsuario, string senhaSha256, string telefone, string celular, string foto)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Genero = genero;
            Email = email;
            NomeUsuario = nomeUsuario;
            SenhaSha256 = senhaSha256;
            Telefone = telefone;
            Celular = celular;
            Foto = foto;
        }
    }
}
