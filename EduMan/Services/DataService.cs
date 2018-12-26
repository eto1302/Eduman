using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Data;

namespace Eduman.Services
{
    public abstract class DataService : BaseService
    {
        protected readonly EdumanDbContext context;

        protected DataService(EdumanDbContext context)
        {
            this.context = context;
        }
    }
}
