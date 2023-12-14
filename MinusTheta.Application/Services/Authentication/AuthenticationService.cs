using MinusTheta.Application.Authentication;

namespace MinusTheta.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Register(string firstname, string lastname, string email, string token)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                firstname,
                lastname,
                email,
                "token");
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstname",
                "lastname",
                email,
                "token");
        }
    }
}
