using Microsoft.Extensions.DependencyInjection;
using MyFinancial.Data.Repositories;
using MyFinancial.Data.Repositories.Interfaces;

namespace MyFinancial.Data
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICompetenceRepository, CompetenceRepository>();
            services.AddScoped<IInputRepository, InputRepository>();
            services.AddScoped<IOutputRepository, OutputRepository>();

            return services;
        }
    }
}
