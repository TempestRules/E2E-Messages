using Application.Accounts.Models;
using MediatR;

namespace Application.Accounts.Handlers.SignInUser
{
    public record SignInUserRequest(LoginModel LoginModel) : IRequest<SignInUserResponse>;
}
