using Application.Authentication;
using Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Accounts.Models;

namespace WebAPI.Accounts
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJWTService _jwtService;

        public AccountController(
            UserManager<AppUser> userManager,
            IJWTService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new AppUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    var token = _jwtService.CreateToken(user);
                    return Created();
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);
            }

            return BadRequest(result.Errors);
        }
    }
}
