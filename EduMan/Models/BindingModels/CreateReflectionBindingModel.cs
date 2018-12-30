using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.BindingModels
{
    public class CreateReflectionBindingModel
    {
        public bool IsCompliment { get; set; } //Determines if it is a Compliment(+) or a Criticism(-)

        public string Description { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }
        
    }
}
