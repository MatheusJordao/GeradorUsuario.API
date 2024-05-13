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

            builder.Property(x => x.Uuid)
                   .ValueGeneratedOnAdd();
            builder.Property(u => u.NomeUsuario).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Senha).IsRequired();
        }
    }
}
