using Domain.Models.Messages;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Users
{
    public class AppUser : IdentityUser
    {
        public required string PublicPgpKey { get; set; }

        public required string PrivatePgpKey { get; set; }

        public List<Message> SentMessages { get; set; } = new();

        public List<Message> ReceivedMessages { get; set; } = new();
    }
}
