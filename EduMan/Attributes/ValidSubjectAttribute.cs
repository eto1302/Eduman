using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Utilities;

namespace Eduman.Attributes
{
    public class ValidSubjectAttribute : ValidationAttribute
    {
        public ValidSubjectAttribute()
        {
            ErrorMessage = "Subject field has to contain a valid subject";
        }

        public override bool IsValid(object value)
        {
            Subjects subject;
            return Enum.TryParse(value.ToString(), out subject);
        }
    }
}
