using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.BindingModels
{
    public class CreateReflectionBindingModel
    {
        [Required(ErrorMessage = "Field whether the reflection is a compliment has to be selected")]
        [Display(Name = "IsCompliment")]
        public bool IsCompliment { get; set; } //Determines if it is a Compliment(+) or a Criticism(-)

        [Required(ErrorMessage = "Description cannot be empty")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Student's First Name cannot be empty")]
        [Display(Name = "StudentFirstName")]
        public string StudentFirstName { get; set; }

        [Required(ErrorMessage = "Student's Last Name cannot be empty")]
        [Display(Name = "StudentLastName")]
        public string StudentLastName { get; set; }

    }
}
