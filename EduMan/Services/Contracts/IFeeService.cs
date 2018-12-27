using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models.BindingModels;
using Eduman.Models.ViewModels;

namespace Eduman.Services.Contracts
{
    public interface IFeeService
    {
        Task CreateAsync(CreateFeeBindingModel absence, string teacherName);
        Task<List<AllFeesViewModel>> GetAllAsync(string UserId);
        Task<FeeDetailsViewModel> GetFeeDetails(string id);
    }
}
