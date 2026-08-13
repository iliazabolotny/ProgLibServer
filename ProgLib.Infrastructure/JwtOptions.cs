namespace ProgLib.Infrastructure
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;

        public int ExpiresSet { get; set; }
    }
}
