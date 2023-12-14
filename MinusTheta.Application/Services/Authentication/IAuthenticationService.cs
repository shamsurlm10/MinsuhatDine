using MinusTheta.Application.Authentication;

namespace MinusTheta.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(string firstname, string lastname, string email, string token);
        AuthenticationResult Login(string email, string password);
    }
}
