using System.ComponentModel.DataAnnotations;

namespace Application.Accounts.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PublicKey { get; set; } = string.Empty;

        [Required]
        public string PrivateKey { get; set; } = string.Empty;
    }
}
