﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduman.Models.ViewModels
{
    public class AllReflectionsViewModel
    {
        public string Id { get; set; }
        
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public string StudentUsername { get; set; }

        public string TeacherUsername { get; set; }
    }
}
