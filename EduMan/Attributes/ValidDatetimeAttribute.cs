using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eduman.Attributes
{
    public class ValidDatetimeAttribute : ValidationAttribute
    {

        public ValidDatetimeAttribute()
        {
            ErrorMessage = "DateTime field has to contain a valid Datetime";
        }

        public override bool IsValid(object value)
        {
            DateTime temp = new DateTime();
            return DateTime.TryParse(value.ToString(), out temp);
        }

    }
}
