using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.BindingModels
{
    public class CreateGradeBindingModel
    {
        public string Subject { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }
    }
}
