using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eduman.Models
{
    public class Grade
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Subject cannot be empty")]
        [RegularExpression(@"\b(Russian Language|German Language|Computer Science|Music|Arts|PE|Geography|History|Psychology|Biology|Chemistry|Physics|English Language|Bulgarian Language|Maths)\b", ErrorMessage = "Subject field should contain a valid subject.")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Value cannot be empty")]
        [Display(Name = "Value")]
        [Range(2, 6, ErrorMessage = "Value has to be between 2 and 6")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Event Date cannot be empty")]
        [Display(Name = "Event Date")]
        [RegularExpression(@"^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$", ErrorMessage = "Datetime has to be a proper date.")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Student's Id cannot be empty")]
        [Display(Name = "StudentId")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Teacher's Id cannot be empty")]
        [Display(Name = "TeacherId")]
        public string TeacherId { get; set; }

    }
}
