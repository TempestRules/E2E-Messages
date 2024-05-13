using Application.Accounts.JWT;
using Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Accounts.Handlers.SignInUser
{
    internal class SignInUserRequestHandler : IRequestHandler<SignInUserRequest, SignInUserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJWTService _jwtService;

        public SignInUserRequestHandler(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IJWTService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<SignInUserResponse> Handle(SignInUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == request.LoginModel.Username);

            if (user != null)
            {
                var signIn = await _signInManager.CheckPasswordSignInAsync(user, request.LoginModel.Password, false);

                if (signIn.Succeeded)
                {
                    var token = _jwtService.CreateToken(user);
                    return new SignInUserResponse(true, token);
                }
            }

            return new SignInUserResponse(false, string.Empty);
        }
    }
}
