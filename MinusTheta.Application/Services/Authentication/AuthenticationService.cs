using MinusTheta.Application.Authentication;
using MinusTheta.Application.Common.Interfaces.Authentication;
using MinusTheta.Application.Persistence;
using MinusTheta.Domain.Entities;

namespace MinusTheta.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _user;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository user)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _user = user;
        }

        public AuthenticationResult Register(string firstname, string lastname, string email, string password)
        {
            if (_user.GetUserByEmail(email) != null)throw new Exception("User already exists");
            User user = new User()
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password
            };
            _user.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            if (_user.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User is not registered");
            }
            if (user.Password != password)
            {
                throw new Exception("Password is incorrect");
            }
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
