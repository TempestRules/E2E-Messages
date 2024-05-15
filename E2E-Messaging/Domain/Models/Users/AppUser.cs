using Domain.Models.Messages;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Users
{
    public class AppUser : IdentityUser
    {
        public string PublicPgpKey { get; set; } = string.Empty;

        public string PrivatePgpKey { get; set; } = string.Empty;

        public List<Message> SentMessages { get; set; } = new();

        public List<Message> ReceivedMessages { get; set; } = new();
    }
}
