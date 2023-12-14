using Microsoft.Extensions.DependencyInjection;
using MinusTheta.Application.Services.Authentication;

namespace MinusTheta.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
