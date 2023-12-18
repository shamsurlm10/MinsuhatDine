using MinusTheta.Application.Authentication;

namespace MinusTheta.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(string firstname, string lastname, string email, string password);
        AuthenticationResult Login(string email, string password);
    }
}
