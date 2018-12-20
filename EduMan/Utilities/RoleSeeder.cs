using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.Utilities
{
    public static class RoleSeeder
    {
        public static void Seed(IServiceProvider provider)
        {
            var roleStore = provider.GetService<RoleManager<IdentityRole>>();
            var studentRole = roleStore.Roles.FirstOrDefault(r => r.Name == "Student");
            if (studentRole == null)
            {
                roleStore.CreateAsync(new IdentityRole("Student"));
            }
            var teacherRole = roleStore.Roles.FirstOrDefault(r => r.Name == "Teacher");
            if (teacherRole == null)
            {
                roleStore.CreateAsync(new IdentityRole("Teacher"));
            }
            var principalRole = roleStore.Roles.FirstOrDefault(r => r.Name == "Principal");
            if (principalRole == null)
            {
                roleStore.CreateAsync(new IdentityRole("Principal"));
            }
        }
    }
}