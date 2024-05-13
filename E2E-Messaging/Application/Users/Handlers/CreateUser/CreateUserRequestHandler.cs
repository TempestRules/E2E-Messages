using Application.Accounts.JWT;
using Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Handlers.CreateUser
{
    internal class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJWTService _jwtService;

        public CreateUserRequestHandler(
            UserManager<AppUser> userManager,
            IJWTService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = request.RegisterModel.Username,
                Email = request.RegisterModel.Email
            };

            var result = await _userManager.CreateAsync(user, request.RegisterModel.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    var jwtToken = _jwtService.CreateToken(user);
                    return new CreateUserResponse(result, jwtToken);
                }
            }

            return new CreateUserResponse(result, string.Empty);
        }
    }
}
