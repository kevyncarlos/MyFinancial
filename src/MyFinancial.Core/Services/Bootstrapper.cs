using Microsoft.Extensions.DependencyInjection;
using MyFinancial.Core.Services.Interfaces;

namespace MyFinancial.Core.Services
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICompetenceService, CompetenceService>();
            services.AddScoped<IInputService, InputService>();
            services.AddScoped<IOutputService, OutputService>();

            return services;
        }
    }
}
