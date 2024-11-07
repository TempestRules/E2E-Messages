using Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Handlers.CheckUsername
{
    internal class CheckUsernameExistsQueryHandler : IRequestHandler<CheckUsernameExistsQuery, bool>
    {
        private readonly UserManager<AppUser> _userManager;

        public CheckUsernameExistsQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CheckUsernameExistsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
