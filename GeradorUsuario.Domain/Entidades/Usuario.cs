namespace GeradorUsuario.Domain.Entidades
{
    public class Usuario(Guid uuid)
    {
        public Guid Uuid { get; private set; } = uuid;

        public void Update()
        {
            
        }
    }
}
