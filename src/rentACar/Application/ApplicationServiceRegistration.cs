using Application.Features.Authorizations.Rules;
using Application.Features.Brands.Rules;
using Application.Features.Cars.Rules;
using Application.Features.Color.Rules;
using Application.Features.FindeksCredits.Rules;
using Application.Features.Fuel.Rules;
using Application.Features.Invoices.Rules.Application.Features.Invoices.Rules;
using Application.Features.Models.Rules;
using Application.Features.Rentals.Rules;
using Application.Features.Transmissions.Rules;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validations;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.ElasticSearch;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddSingleton<LoggerServiceBase, FileLogger>();
            services.AddSingleton<IElasticSearch, ElasticSearchManager>();

            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<ModelBusinessRules>();
            services.AddScoped<CarBusinessRules>();
            services.AddScoped<CarStateBusinessRule>();
            services.AddScoped<ColorBusinessRules>();
            services.AddScoped<FuelBusinessRules>();
            services.AddScoped<RentalBusinessRules>();
            services.AddScoped<TransmissionBusinessRules>();
            services.AddScoped<FindeksCreditBusinessRules>();
            services.AddScoped<InvoiceBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));

            return services;
        }
    }
}
