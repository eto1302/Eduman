﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eduman.Attributes;
using Eduman.Mapping;

namespace Eduman.Models.BindingModels
{
    public class CreateAbsenceBindingModel
    {
        [RegularExpression(@"\b(Russian Language|German Language|Computer Science|Music|Arts|PE|Geography|History|Psychology|Biology|Chemistry|Physics|English Language|Bulgarian Language|Maths)\b", ErrorMessage = "Subject field should contain a valid subject.")]
        [Required(ErrorMessage = "Subject cannot be empty")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [RegularExpression(@"^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$", ErrorMessage = "Datetime has to be a proper date.")]
        [Required(ErrorMessage = "Date Absent cannot be empty")]
        [Display(Name = "DateAbsent")]
        public DateTime DateAbsent { get; set; }

        [Required(ErrorMessage = "Student's First Name cannot be empty")]
        [Display(Name = "StudentFirstName")]
        public string StudentFirstName { get; set; }

        [Required(ErrorMessage = "Student's Last Name cannot be empty")]
        [Display(Name = "StudentLastName")]
        public string StudentLastName { get; set; }
    }
}
