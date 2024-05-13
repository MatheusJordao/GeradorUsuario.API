using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeradorUsuario.Domain.Entidades
{
    public class Usuario(string nomeUsuario, string email, string senha)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uuid { get; private set; } = Guid.NewGuid();
        public string NomeUsuario { get; private set; } = nomeUsuario;
        public string Email { get; private set; } = email;
        public string Senha { get; private set; } = senha;

        public void Update(string senha, string email, string nomeUsuario)
        {
            Email = email;
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }
    }
}
