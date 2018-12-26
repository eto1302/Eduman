using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Data;
using Eduman.Models;
using Eduman.Services.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Eduman.Services
{
    public class AccountService : IAccountService
    {
        public EdumanDbContext context;

        public AccountService(EdumanDbContext context)
        {
            this.context = context;
        }

        
    }
}
