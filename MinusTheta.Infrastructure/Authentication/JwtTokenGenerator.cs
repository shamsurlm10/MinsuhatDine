using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinusTheta.Application.Common.Interfaces.Authentication;
using MinusTheta.Application.Common.Interfaces.Services;
using MinusTheta.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinusTheta.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtToken _options;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtToken> options)
        {
            _dateTimeProvider = dateTimeProvider;
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            var signingCredential = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secrete)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };
            var securityToken = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    claims: claims,
                    expires: _dateTimeProvider.UtcNow.AddMinutes(_options.Expires),
                    signingCredentials: signingCredential);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
