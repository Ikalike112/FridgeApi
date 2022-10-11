﻿using Application.Interfaces;
using Filters.ActionFilters.FridgeFilters;
using Filters.ActionFilters.FridgeModelFilters;
using Filters.ActionFilters.FridgeProductFilters;
using Filters.ActionFilters.ProductFilters;
using FridgeApi.Options;
using FridgeApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System.IO.Abstractions;

namespace FridgeApi.Extensions
{
    public static class ServiceExtentions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services) =>
services.AddScoped<ILoggerManager, LoggerManager>();
        public static void ConfigureSqlContext(this IServiceCollection services,
   IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<FridgeDbContext>(options =>
            {
                options.UseSqlServer(connectionString, migration =>
                        migration.MigrationsAssembly("Persistence"));
            });
            services.AddScoped<IFridgeDbContext>(provider =>
provider.GetService<FridgeDbContext>());
        }
        public static void ConfigureImageService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ImageServiceOptions>(configuration.GetSection(nameof(ImageServiceOptions)));
            services.AddScoped<IFileSystem, FileSystem>();
            services.AddScoped<IImageService, ImageService>();
        }
        public static void ConfigureActionFilters(this IServiceCollection services)
        {

            services.AddScoped<ValidateFridgeProductForManipulateAttribute>();
            services.AddScoped<ValidateFridgeProductExistsAttribute>();
            services.AddScoped<ValidateProductExistsAttribute>();
            services.AddScoped<ValidateFridgeModelForManipulateFridgeAttribute>();
            services.AddScoped<ValidateFridgeExistsAtrribute>();
            services.AddScoped<ValidateFridgeModelExistsAttribute>();

        }
    }
}
