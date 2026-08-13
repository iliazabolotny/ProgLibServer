using System.ComponentModel.DataAnnotations;

namespace ProgLib.API.Contracts
{
    public record RegisterUserRequest(string UserName, [Required] string Email, [Required] string Password);
}
