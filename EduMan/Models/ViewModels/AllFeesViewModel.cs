using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.ViewModels
{
    public class AllFeesViewModel
    {
        public string Id { get; set; }
        
        public DateTime DueDate { get; set; }

        public string StudentUsername { get; set; }

        public string TeacherUsername { get; set; }
        
        public int Cost { get; set; }

        
    }
}
