using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.ViewModels
{
    public class AllEventsViewModel
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public DateTime EventDate { get; set; }

        public string StudentUsername { get; set; }

        public string TeacherUsername { get; set; }
    }
}
