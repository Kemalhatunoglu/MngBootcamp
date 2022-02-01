﻿using Application.Features.Brands.Rules;
using Application.Features.Cars.Rules;
using Application.Features.Models.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<ModelBusinessRules>();
            services.AddScoped<CarBusinessRules>();

            return services;
        }
    }
}
