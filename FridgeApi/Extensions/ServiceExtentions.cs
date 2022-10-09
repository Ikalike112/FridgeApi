using Application.Interfaces;
using Filters.ActionFilters;
using Filters.ActionFilters.FridgeFilters;
using Filters.ActionFilters.FridgeProductFilters;
using FridgeApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

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
        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidateFridgeProductForManipulateAttribute>();
            services.AddScoped<ValidateFridgeProductExistsAttribute>();
            services.AddScoped<ValidateProductExistsAttribute>();
            services.AddScoped<ValidateFridgeModelForManipulateFridgeAttribute>();
            services.AddScoped<ValidateFridgeExistsAtrribute>();

        }
    }
}
