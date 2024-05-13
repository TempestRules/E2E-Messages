using Microsoft.AspNetCore.Identity;

namespace Application.Users.Handlers.CreateUser
{
    public record CreateUserResponse(IdentityResult UserResult, string JwtToken);
}
