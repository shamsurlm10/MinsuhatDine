namespace MinusTheta.Infrastructure.Authentication
{
    public class JwtToken
    {
        public string? Secrete { get; init; }
        public string? Issuer { get; init; }
        public string? Audience { get; init; }
        public int Expires { get; init; }
    }
}
