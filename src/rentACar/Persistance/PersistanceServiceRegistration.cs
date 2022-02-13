using Application.Services.Repositories;
using Core.Security.Jwt;
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
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
            services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
            services.AddScoped<IFindeksCreditRepository, FindeksCreditRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDamageRecordRepository, DamageRecordRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IAdditionalServiceRepository, AdditionalServiceRepository>();
            services.AddScoped<IRentalAdditionalServiceRepository, RentalAdditionalServiceRepository>();

            return services;
        }
    }
}
