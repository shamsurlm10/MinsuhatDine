using Microsoft.Extensions.DependencyInjection;
using MinusTheta.Application.Services.Authentication;

namespace MinusTheta.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            
            return services;
        }
    }
}
