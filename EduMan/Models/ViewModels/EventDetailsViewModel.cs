using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.ViewModels
{
    public class EventDetailsViewModel
    {
         public string Type { get; set; }

        public string Description { get; set; }

        public DateTime EventDate { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public string TeacherFirstName { get; set; }

        public string TeacherLastName { get; set; }

        public string School { get; set; }
    }
}
