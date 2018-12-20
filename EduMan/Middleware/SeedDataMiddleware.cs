using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.Middlewares
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<EdumanUser>>();
            var teacher = await userManager.FindByEmailAsync("teacher@teacherpass");
            var principal = await userManager.FindByEmailAsync("principal@principalpass");
            var student = await userManager.FindByEmailAsync("student@studentpass");
            if (teacher == null)
            {
                var user = new EdumanUser()
                {
                    UserName = "teacher",
                    FirstName = "Petar",
                    LastName = "Petrov",
                    Email = "teacher@teacherpass",
                    School = "RNDSchool",
                    Number = 0
                };

                await userManager.CreateAsync(user, "teacherpass");

                await userManager.AddToRoleAsync(user, "Teacher");
            }
            if (principal == null)
            {
                var user = new EdumanUser()
                {
                    UserName = "principal",
                    FirstName = "Petko",
                    LastName = "Petkov",
                    School = "RNDSchool",
                    Email = "principal@principalpass",
                    Number = 0
                };

                await userManager.CreateAsync(user, "principalpass");

                await userManager.AddToRoleAsync(user, "Principal");
            }
            if (student == null)
            {
                var user = new EdumanUser()
                {
                    UserName = "student",
                    FirstName = "Georgi",
                    LastName = "Georgiev",
                    School = "RNDSchool",
                    Email = "student@studentpass",
                    Number = 0
                };

                await userManager.CreateAsync(user, "studentpass");

                await userManager.AddToRoleAsync(user, "Student");
            }
            await next(httpContext);
        }
    }
}