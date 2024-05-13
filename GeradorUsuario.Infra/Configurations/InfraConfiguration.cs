using GeradorUsuario.Domain.Interfaces;
using GeradorUsuario.Infra.Data;
using GeradorUsuario.Infra.Persistence.Repositories;
using GeradorUsuario.Infra.ServicosExternos.RandomUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeradorUsuario.Infra.Configurations
{
    public static class InfraConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("UserDbCs");
            services.AddDbContext<UserDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IRandomRepository, RandomRepository>();
            
            return services;
        }
    }
}
