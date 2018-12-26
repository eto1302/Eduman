using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eduman.Mapping;

namespace Eduman.Models.BindingModels
{
    public class CreateAbsenceBindingModel
    {

        public string Subject { get; set; }

        public DateTime DateAbsent { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        
    }
}
