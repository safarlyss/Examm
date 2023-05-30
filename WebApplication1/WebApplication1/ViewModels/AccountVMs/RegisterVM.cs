﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.AccountVMs
{
    public class RegisterVM
    {
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [MaxLength(255)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
