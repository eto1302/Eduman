using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.BindingModels
{
    public class CreateEventBindingModel
    {
        public string Description { get; set; }

        public string Type { get; set; }

        public DateTime EventDate { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }
    }
}
