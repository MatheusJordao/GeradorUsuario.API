using GeradorUsuario.Application.Interfaces;
using GeradorUsuario.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GeradorUsuario.Application.Configurations
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddServicesApplication(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            
            return services;
        }
    }
}
