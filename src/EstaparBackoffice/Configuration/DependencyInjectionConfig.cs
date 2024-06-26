﻿using EstaparGarage.business.Interfaces;
using EstaparGarage.business.Notificacoes;
using EstaparGarage.business.Services;
using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Data.Context;
using EstaparGarage.Data.Repository;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EstaparBackoffice.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<EstaparDbcontext>();
            services.AddScoped<IPassagemRepository, PassagemRepository>();
            services.AddScoped<IGaragemRepository, GaragemRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<IPassagemService, PassagemService>();
            services.AddScoped<IGaragemService, GarageService>();
            

            services.AddScoped<INotificador, Notificador>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
