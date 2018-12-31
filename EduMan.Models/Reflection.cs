using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eduman.Models
{
    public class Reflection
    {
        public string Id { get; set; }

        public bool IsCompliment { get; set; } //Determines if it is a Compliment(+) or a Criticism(-)

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Student's Id cannot be empty")]
        [Display(Name = "StudentId")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Teacher's Id cannot be empty")]
        [Display(Name = "TeacherId")]
        public string TeacherId { get; set; }
    }
}
