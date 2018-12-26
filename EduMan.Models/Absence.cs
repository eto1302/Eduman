using System;
using System.Collections.Generic;
using System.Text;

namespace Eduman.Models
{
    public class Absence
    {
        public string Id { get; set; }

        public string Subject { get; set; }
        
        public DateTime DateAbsent { get; set; }

        public string StudentId { get; set; }

        public string TeacherId { get; set; }
    }
}
