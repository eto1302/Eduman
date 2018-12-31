using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Attributes;

namespace Eduman.Models.BindingModels
{
    public class CreateGradeBindingModel
    {
        [Required(ErrorMessage = "Subject cannot be empty")]
        [RegularExpression(@"\b(Russian Language|German Language|Computer Science|Music|Arts|PE|Geography|History|Psychology|Biology|Chemistry|Physics|English Language|Bulgarian Language|Maths)\b", ErrorMessage = "Subject field should contain a valid subject.")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Value cannot be empty")]
        [Display(Name = "Value")]
        [Range(2,6,ErrorMessage = "Value has to be between 2 and 6")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Student's First Name cannot be empty")]
        [Display(Name = "StudentFirstName")]
        public string StudentFirstName { get; set; }

        [Required(ErrorMessage = "Student's Last Name cannot be empty")]
        [Display(Name = "StudentLastName")]
        public string StudentLastName { get; set; }
    }
}
