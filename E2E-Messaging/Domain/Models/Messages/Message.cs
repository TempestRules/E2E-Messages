using Domain.Models.Users;

namespace Domain.Models.Messages
{
    public class Message
    {
        public Guid Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime SentAt { get; set; }

        public AppUser Sender { get; set; } = null!;

        public AppUser Receiver { get; set; } = null!;
    }
}
