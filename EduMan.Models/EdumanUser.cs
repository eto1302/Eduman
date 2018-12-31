using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Eduman.Models
{
    public class EdumanUser : IdentityUser
    {
        [Required(ErrorMessage = "First Name cannot be empty")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "School cannot be empty")]
        [Display(Name = "School")]
        public string School { get; set; }

        [Required(ErrorMessage = "Number cannot be empty")]
        [Display(Name = "Number")]
        public int Number { get; set; }


        public bool IsConfirmed { get; set; }
    }
}
