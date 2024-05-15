using Application.Accounts.Handlers.SignInUser;
using Application.Accounts.Models;
using Application.Users.Handlers.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Accounts
{
    [Route("api/account")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var signInResult = await _mediator.Send(new SignInUserRequest(model));

            if (signInResult.SignInSucceded)
            {
                return Ok(signInResult.JwtToken);
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createUserResult = await _mediator.Send(new CreateUserRequest(model));

            if (createUserResult.UserResult.Succeeded)
            {
                return Accepted(createUserResult.JwtToken);
            }

            return BadRequest(createUserResult.UserResult.Errors);
        }
    }
}
