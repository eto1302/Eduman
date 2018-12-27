using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models.BindingModels;
using Eduman.Models.ViewModels;

namespace Eduman.Services.Contracts
{
    public interface IGradeService
    {
        Task CreateAsync(CreateGradeBindingModel gradeBindingModel, string teacherName);
        Task<List<AllGradesViewModel>> GetAllAsync(string UserId);
        Task<GradeDetailsViewModel> GetGradeDetails(string id);
    }
}
