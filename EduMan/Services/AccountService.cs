using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Data;
using Eduman.Models;
using Eduman.Models.ViewModels;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Eduman.Services
{
    public class AccountService : DataService, IAccountService
    {
        private UserManager<EdumanUser> userManager;

        public AccountService(EdumanDbContext context, UserManager<EdumanUser> userManager) : base(context)
        {
            this.userManager = userManager;
        }

        public void ConfirmUser(string id)
        {
            EdumanUser user = this.context.Users.FirstOrDefault(u =>
                 u.Id == id &&
                 !u.IsConfirmed);
            if (user == null)
            {
                throw new Exception("The User is non-existent");
            }

            user.IsConfirmed = true;
            this.context.Users.Update(user);
            this.context.SaveChanges();

        }

        public async Task<List<ConfirmUserViewModel>> GetAllUnconfirmedUsersAsync(string Username)
        {
            string School = this.context.Users.FirstOrDefault(u => u.UserName == Username).School;
            List<EdumanUser> unconfirmedUsers =
                this.context.Users.Where(u => u.School == School && !u.IsConfirmed).ToList();
            List<ConfirmUserViewModel> resultUsers = new List<ConfirmUserViewModel>();
            
            foreach (var user in unconfirmedUsers)
            {
                var role = (await this.userManager.GetRolesAsync(user))[0];
                resultUsers.Add(new ConfirmUserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = role,
                    Username = user.UserName,
                    Id = user.Id
                });
            }

            return resultUsers;
        }
    }
}
