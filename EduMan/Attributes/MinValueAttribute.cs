using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Attributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int _minValue;

        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            return (int)value <= _minValue;
        }
    }
}
