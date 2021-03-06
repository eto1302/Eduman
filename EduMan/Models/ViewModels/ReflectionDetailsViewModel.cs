﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.ViewModels
{
    public class ReflectionDetailsViewModel
    {
        public bool IsCompliment { get; set; } //Determines if it is a Compliment(+) or a Criticism(-)

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public string TeacherFirstName { get; set; }

        public string TeacherLastName { get; set; }
    }
}
