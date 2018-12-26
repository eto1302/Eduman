using System;
using System.Collections.Generic;
using System.Text;

namespace Eduman.Models
{
    public class Grade
    {
        public string Id { get; set; }
        
        public string Subject { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime DateCreated { get; set; }

        public string StudentId { get; set; }

        public string TeacherId { get; set; }

    }
}
