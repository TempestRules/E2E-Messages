namespace Application.Accounts.JWT
{
    public class JWTOptions
    {
        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public string SigningKey { get; set; } = string.Empty;
    }
}
