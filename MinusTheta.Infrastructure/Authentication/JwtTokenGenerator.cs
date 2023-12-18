using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinusTheta.Application.Common.Interfaces.Authentication;
using MinusTheta.Application.Common.Interfaces.Services;
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

        public string GenerateToken(Guid userId, string firstname, string lastname)
        {
            var signingCredential = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secrete)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
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
