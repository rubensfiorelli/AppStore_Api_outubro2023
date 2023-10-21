using AppStore.Application.Interfaces;
using AppStore.Application.Jwt;
using AppStore.Application.Services;
using AppStore.Data.DataContext;
using AppStore.Data.Repositories;
using AppStore.Domain.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AppStore.CrossCutting.DataModule
{
    public static class DataAccessModule
    {
        public static IServiceCollection AddApplications(this IServiceCollection services, IConfiguration configuration)
        {
            services
                 .AddRepositories()
                 .AddJwtServices()
                 .AddServices();


            services
                .AddDbContextPool<ApplicationDbContext>(opts => opts
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
                .UseSqlServer(configuration
                .GetConnectionString("SQLConnection"), b => b
                .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));


            return services;

        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            return services;

        }

        private static IServiceCollection AddJwtServices(this IServiceCollection services)
        {
            services.AddTransient<TokenService>();

            var key = Encoding.ASCII.GetBytes(ConfigurationJwt.JwtKey);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(t =>
            {
                t.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;

        }

    }
}
