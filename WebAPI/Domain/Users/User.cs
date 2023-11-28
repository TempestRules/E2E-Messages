using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.Messages;

namespace WebAPI.Domain.Users
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        // Additional user properties, if needed
        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
    }
}
