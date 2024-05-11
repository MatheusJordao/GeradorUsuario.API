using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Infra.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Uuid);

            builder
                .HasOne(u => u.Endereco)
                .WithOne()
                .HasForeignKey<Endereco>(e => e.UsuarioID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
