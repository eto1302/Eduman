using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.BindingModels
{
    public class CreateFeeBindingModel
    {
        public string Description { get; set; }

        public int Cost { get; set; }

        public DateTime DueDate { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }
    }
}
