using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GeradorUsuario.Domain.Entidades;

namespace GeradorUsuario.Infra.Persistence.Configurations
{
    public class EnderecoConfigurations : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Uuid);
        }
    }
}
