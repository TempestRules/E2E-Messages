using Domain.Models.Messages;
using Domain.Models.Users;
using Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Messages.Handlers.SendMessage
{
    internal class SendMessageRequestHandler : IRequestHandler<SendMessageRequest>
    {
        private readonly E2EMessagingDatabaseContext _context;

        public SendMessageRequestHandler(E2EMessagingDatabaseContext e2EMessagingDatabaseContext)
        {
            _context = e2EMessagingDatabaseContext;
        }

        public async Task Handle(SendMessageRequest request, CancellationToken cancellationToken)
        {
            var sender = await _context.Set<AppUser>().FirstAsync(u => u.UserName == request.SendMessageModel.SenderUsername);
            var receiver = await _context.Set<AppUser>().FirstAsync(u => u.UserName == request.SendMessageModel.ReceiverUsername);

            var message = new Message
            {
                Sender = sender,
                Receiver = receiver,
                Content = request.SendMessageModel.Content,
                SentAt = DateTime.UtcNow
            };

            await _context.Set<Message>().AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
}
