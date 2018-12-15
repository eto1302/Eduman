using System;
using System.Collections.Generic;
using System.Text;

namespace Eduman.Models
{
    public class Reflection
    {
        public string Id { get; set; }

        public bool IsCompliment { get; set; } //Determines if it is a Compliment(+) or a Criticism(-)

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public EdumanUser Student { get; set; }

        public EdumanUser Teacher { get; set; }
    }
}
