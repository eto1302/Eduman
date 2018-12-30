using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models.BindingModels;
using Eduman.Models.ViewModels;

namespace Eduman.Services.Contracts
{
    public interface IReflectionService
    {
        Task CreateAsync(CreateReflectionBindingModel reflectionBindingModel, string teacherName);
        Task<List<AllReflectionsViewModel>> GetAllComplimentsAsync(string UserId);
        Task<List<AllReflectionsViewModel>> GetAllCriticismsAsync(string UserId);
        Task<ReflectionDetailsViewModel> GetReflectionDetails(string id);
    }
}
