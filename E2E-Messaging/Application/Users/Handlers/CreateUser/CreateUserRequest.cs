using Application.Accounts.Models;
using MediatR;

namespace Application.Users.Handlers.CreateUser
{
    public record CreateUserRequest(RegisterModel RegisterModel) : IRequest<CreateUserResponse>;
}
