using Domain.Models.Users;

namespace Application.Accounts.JWT
{
    public interface IJWTService
    {
        string CreateToken(AppUser user);
    }
}
