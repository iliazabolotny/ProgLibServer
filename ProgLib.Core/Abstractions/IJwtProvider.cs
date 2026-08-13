using ProgLib.Core.Models;

namespace ProgLib.Core.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
