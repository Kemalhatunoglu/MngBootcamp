using Application.Services.OutService;
using Application.Services.OutService.IPosService;
using Infrastructure.ServiceAdaters;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFindeksCreditService, FakeFindeksCreditServiceAdapter>();
            services.AddScoped<IPosService, PosServiceAdapter>();
            return services;
        }
    }
}
