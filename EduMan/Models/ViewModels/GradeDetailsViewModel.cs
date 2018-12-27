using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.ViewModels
{
    public class GradeDetailsViewModel
    {
        public string Subject { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime DateCreated { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public string TeacherFirstName { get; set; }

        public string TeacherLastName { get; set; }
    }
}
