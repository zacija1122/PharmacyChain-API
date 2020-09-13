using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PharmacyChain.Contract;
using PharmacyChain.Repository;
using PharmacyChain.Repository.IRepository;
using System;

namespace PharmacyChain.Services
{
    public static class DependecyInjection
    {
        public static void AddDependecyInjection(this IServiceCollection services)
        {
           services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\PharmacyChain.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PharmacyChain",
                });

            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IPharmacyRepo, PharmacyRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();

        }
    }
}
