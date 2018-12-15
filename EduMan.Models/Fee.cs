using System;
using System.Collections.Generic;
using System.Text;

namespace Eduman.Models
{
    public class Fee
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public int Cost { get; set; }

        public DateTime DueDate { get; set; }

        public EdumanUser Teacher { get; set; }

        public EdumanUser Student { get; set; }
    }
}
