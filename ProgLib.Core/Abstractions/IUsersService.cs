using ProgLib.Core.Models;

namespace ProgLib.Core.Abstractions
{
    public interface IUsersService
    {
        Task Register(string userName, string email, string password);

        Task<string> Login(string email, string password);
    }
}
