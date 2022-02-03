using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;

namespace Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACarConnectionString")));

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IFuelRepository, FuelRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<ITransmissionRepository, TransmissionRepository>();

            return services;
        }
    }
}
