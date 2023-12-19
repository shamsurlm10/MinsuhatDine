using MinusTheta.Domain.Entities;

namespace MinusTheta.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
