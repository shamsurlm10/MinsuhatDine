using MinusTheta.Domain.Entities;

namespace MinusTheta.Application.Authentication;

public record AuthenticationResult(
                User? User,
                string Token
    );
