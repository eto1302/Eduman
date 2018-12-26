using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eduman.Mapping;

namespace Eduman.Models.ViewModels
{
    public class AllAbsencesViewModel
    {
        public string StudentName { get; set; }

        public string TeacherName { get; set; }
        
        public string Subject { get; set; }

        public DateTime DateAbsent { get; set; }
        
    }
}
