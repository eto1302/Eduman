using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.BindingModels
{
    public class RegisterBindingModel
    {

        [Required]
        [Display(Name = "Username")]
        [MinLength(5, ErrorMessage = "Username should be at least 5 symbols long and should contain numbers and letters only.")]
        [RegularExpression(@"[a-zA-Z0-9]+")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First Name cannot be empty")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Number cannot be empty")]
        [Display(Name = "Number")]
        public int Number { get; set; }

        [Required(ErrorMessage = "School cannot be empty")]
        [Display(Name = "School")]
        public string School { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}
