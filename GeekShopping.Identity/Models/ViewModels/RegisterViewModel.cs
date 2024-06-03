﻿using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Identity.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string? ConfirmPassword { get; set; }
    }
}
