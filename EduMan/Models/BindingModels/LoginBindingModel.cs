﻿using System.ComponentModel.DataAnnotations;

namespace Eduman.Models.BindingModels
{
    public class LoginBindingModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
