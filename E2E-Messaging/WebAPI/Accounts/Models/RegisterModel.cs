﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Accounts.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
