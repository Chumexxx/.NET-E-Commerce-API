﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs.Account
{
    public class CustomerRegisterDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string HomeAddress { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string PasswordComfirmation { get; set; } = string.Empty;
    }
}
