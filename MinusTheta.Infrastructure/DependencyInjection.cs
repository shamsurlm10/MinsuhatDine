using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinusTheta.Application.Common.Interfaces.Authentication;
using MinusTheta.Application.Common.Interfaces.Services;
using MinusTheta.Application.Persistence;
using MinusTheta.Infrastructure.Authentication;
using MinusTheta.Infrastructure.Persistence;
using MinusTheta.Infrastructure.Services;

namespace MinusTheta.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtToken>(configuration.GetSection("JwtSettings"));
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserReposiory>();
            return services;
        }
    }
}
