using MediatR;

namespace Application.Users.Handlers.CheckUsername
{
    public record CheckUsernameExistsQuery(string Username) : IRequest<bool>;
}
