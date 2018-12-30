using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models;
using Eduman.Models.ViewModels;

namespace Eduman.Services.Contracts
{
    public interface IAccountService
    {
        void ConfirmUser(string id);
        Task<List<ConfirmUserViewModel>> GetAllUnconfirmedUsersAsync(string Username);
    }
}
