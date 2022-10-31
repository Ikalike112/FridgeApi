using Application.Services.Implementations;
using Application.Services.Interfaces;
using Domain.Entities;
using Filters.ActionFilters.FridgeFilters;
using Filters.ActionFilters.FridgeModelFilters;
using Filters.ActionFilters.FridgeProductFilters;
using Filters.ActionFilters.ProductFilters;
using FridgeApi.Options;
using FridgeApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Reflection;
using System.Text;

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
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<FridgeDbContext>()
    .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            });
        }
        public static void ConfigureImageService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ImageServiceOptions>(configuration.GetSection(nameof(ImageServiceOptions)));
            services.AddScoped<IFileSystem, FileSystem>();
            services.AddScoped<IImageService, ImageService>();
        }
        public static void ConfigureJwt(this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET",EnvironmentVariableTarget.Machine);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FridgeAPI",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Dima Korets",
                        Url = new Uri("https://github.com/Ikalike112")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Add your JWT using \"Bearer 'your jwt token here'\"",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                        },
                        new string[] {}
                    }
                });
            });
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
