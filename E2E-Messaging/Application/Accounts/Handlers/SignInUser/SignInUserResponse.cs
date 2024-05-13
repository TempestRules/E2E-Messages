using Microsoft.AspNetCore.Identity;

namespace Application.Accounts.Handlers.SignInUser
{
    public record SignInUserResponse(bool SignInSucceded, string JwtToken);
}
