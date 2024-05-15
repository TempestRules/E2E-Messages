using Application.Messages.Models;
using MediatR;

namespace Application.Messages.Handlers.SendMessage
{
    public record SendMessageRequest(SendMessageModel SendMessageModel) : IRequest;
}
