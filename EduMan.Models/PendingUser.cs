using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace Eduman.Models
{
    public class PendingUser
    {
        public string Id { get; set; }

        public EdumanUser User { get; set; }

        public string Role { get; set; }
    }

}
