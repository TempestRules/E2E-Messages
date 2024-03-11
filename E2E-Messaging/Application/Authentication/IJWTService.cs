using Domain.Models.Users;

namespace Application.Authentication
{
    public interface IJWTService
    {
        string CreateToken(AppUser user);
    }
}
