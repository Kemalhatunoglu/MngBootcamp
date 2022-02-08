using Application.Services.OutService;
using Infrastructure.ServiceAdaters;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFindeksCreditService, FakeFindeksCreditServiceAdapter>();
            return services;
        }
    }
}
