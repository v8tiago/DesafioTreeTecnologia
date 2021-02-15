using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjetoTree.Business.Interfaces;
using ProjetoTree.Business.Notificacoes;
using ProjetoTree.Business.Services;
using ProjetoTree.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProjetoTree.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStarshipRepository, StarshipRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IPlanetRepository, PlanetRepository>();
            services.AddScoped<ITravelService, TravelService>();

            services.AddScoped<INotificador, Notificador>();
           // services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
