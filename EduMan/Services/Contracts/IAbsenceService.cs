using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models;
using Eduman.Models.BindingModels;
using Eduman.Models.ViewModels;

namespace Eduman.Services.Contracts
{
    public interface IAbsenceService
    {
        Task CreateAsync(CreateAbsenceBindingModel absence, string teacherName);
        Task<List<AllAbsencesViewModel>> GetAllAsync(string UserId);
    }
}
