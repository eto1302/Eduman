using System;
using System.Collections.Generic;
using System.Text;

namespace Eduman.Models
{
    public class Event
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public DateTime EventDate { get; set; }

        public EdumanUser Student { get; set; }

        public EdumanUser Teacher { get; set; }
    }
}
