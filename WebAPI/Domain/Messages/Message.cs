using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.Users;

namespace WebAPI.Domain.Messages
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public DateTime SentAt { get; set; }

        public User Sender { get; set; }

        public User Receiver { get; set; }
    }
}
