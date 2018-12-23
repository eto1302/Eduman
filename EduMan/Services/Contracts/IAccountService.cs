using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models;

namespace Eduman.Services.Contracts
{
    public interface IAccountService
    {
        void AddUserToPending(EdumanUser user, string Role);
    }
}
