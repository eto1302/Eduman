﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eduman.Models
{
    public class Fee
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Cost cannot be empty and should be positive integer")]
        [Display(Name = "Cost")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Due Date cannot be empty and should be positive integer")]
        [Display(Name = "DueDate")]
        [RegularExpression(@"^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$", ErrorMessage = "Datetime has to be a proper date.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Student's Id cannot be empty")]
        [Display(Name = "StudentId")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Teacher's Id cannot be empty")]
        [Display(Name = "TeacherId")]
        public string TeacherId { get; set; }
    }
}
