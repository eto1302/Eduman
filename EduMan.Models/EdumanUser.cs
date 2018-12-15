using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Eduman.Models
{
    public class EdumanUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string School { get; set; }

        public int Number { get; set; }
    }
}
