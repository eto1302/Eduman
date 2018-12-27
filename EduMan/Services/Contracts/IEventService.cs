using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models.BindingModels;
using Eduman.Models.ViewModels;

namespace Eduman.Services.Contracts
{
    public interface IEventService
    {
        Task CreateAsync(CreateEventBindingModel absence, string teacherName);
        Task<List<AllEventsViewModel>> GetAllAsync(string UserId);
        Task<EventDetailsViewModel> GetEventDetails(string id);
    }
}
