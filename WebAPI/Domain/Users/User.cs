using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.Messages;

namespace WebAPI.Domain.Users
{
    public class User : IdentityUser
    {
        // Additional user properties, if needed
        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
    }
}
