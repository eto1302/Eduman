using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduman.Models;
using Eduman.Models.BindingModels;
using Eduman.Services.Contracts;
using Eduman.Tests.Eduman.Services.Tests.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Eduman.Tests.Eduman.Services.Tests.Account
{
    [TestFixture]
    public class AccountServiceTests : BaseServiceTest
    {
        private UserManager<EdumanUser> userManager => this.Provider.GetRequiredService<UserManager<EdumanUser>>();
        private IAccountService accountService => this.Provider.GetRequiredService<IAccountService>();
        private RoleManager<IdentityRole> roleManager => this.Provider.GetRequiredService<RoleManager<IdentityRole>>();

        [Test]
        public async Task GetAllUnconfirmed_WithValidData_ShouldReturnCorrectData()
        {
            await roleManager.CreateAsync(new IdentityRole("Student"));
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
            await roleManager.CreateAsync(new IdentityRole("Principal"));

            EdumanUser user = new EdumanUser
            {
                UserName = "studentName",
                FirstName = "Student",
                LastName = "TestName",
                IsConfirmed = false,
                Id = "TestStudentId",
                School = "TestSchool"
            };

            EdumanUser principal = new EdumanUser
            {
                UserName = "principalName",
                FirstName = "Principal",
                LastName = "TestName",
                IsConfirmed = true,
                Id = "TestPrincipalId",
                School = "TestSchool"
            };

            this.userManager.CreateAsync(user).GetAwaiter();
            this.userManager.CreateAsync(principal).GetAwaiter();

            userManager.AddToRoleAsync(user, "Student").GetAwaiter();
            userManager.AddToRoleAsync(principal, "Principal").GetAwaiter();

            this.Context.SaveChanges();

            var users = this.accountService.GetAllUnconfirmedUsersAsync("principalName").Result;
            var result = users.FirstOrDefault();
            // Assert
            Assert.AreEqual(1, users.Count);
            Assert.AreEqual("studentName", result.Username);
            Assert.AreEqual(user.Id, result.Id);
            Assert.AreEqual("Student", result.FirstName);
            Assert.AreEqual("TestName", result.LastName);
            Assert.AreEqual("Student", result.Role);
            Assert.AreEqual(false, user.IsConfirmed);
        }

        [Test]
        public async Task ConfirmUser_WithValidData_ShouldConfirmUser()
        {
            await roleManager.CreateAsync(new IdentityRole("Student"));
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
            await roleManager.CreateAsync(new IdentityRole("Principal"));

            EdumanUser user = new EdumanUser
            {
                UserName = "studentName",
                FirstName = "Student",
                LastName = "TestName",
                IsConfirmed = false,
                Id = "TestStudentId",
                School = "TestSchool"
            };

            EdumanUser principal = new EdumanUser
            {
                UserName = "principalName",
                FirstName = "Principal",
                LastName = "TestName",
                IsConfirmed = true,
                Id = "TestPrincipalId",
                School = "TestSchool"
            };

            this.userManager.CreateAsync(user).GetAwaiter();
            this.userManager.CreateAsync(principal).GetAwaiter();

            userManager.AddToRoleAsync(user, "Student").GetAwaiter();
            userManager.AddToRoleAsync(principal, "Principal").GetAwaiter();

            this.Context.SaveChanges();

            this.accountService.ConfirmUser("TestStudentId");
            
            // Assert
            Assert.True(user.IsConfirmed);
            
        }

        [Test]
        public async Task ConfirmUser_WithWrongId_ShouldNotConfirmUser()
        {
            await roleManager.CreateAsync(new IdentityRole("Student"));
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
            await roleManager.CreateAsync(new IdentityRole("Principal"));

            EdumanUser user = new EdumanUser
            {
                UserName = "studentName",
                FirstName = "Student",
                LastName = "TestName",
                IsConfirmed = false,
                Id = "TestStudentId",
                School = "TestSchool"
            };

            EdumanUser principal = new EdumanUser
            {
                UserName = "principalName",
                FirstName = "Principal",
                LastName = "TestName",
                IsConfirmed = true,
                Id = "TestPrincipalId",
                School = "TestSchool"
            };

            this.userManager.CreateAsync(user).GetAwaiter();
            this.userManager.CreateAsync(principal).GetAwaiter();

            userManager.AddToRoleAsync(user, "Student").GetAwaiter();
            userManager.AddToRoleAsync(principal, "Principal").GetAwaiter();

            this.Context.SaveChanges();

            

            // Assert
            var ex = Assert.Throws<Exception>(() => accountService.ConfirmUser("WrongStudentId"));

            Assert.AreEqual(ex.Message, "The User is non-existent");

        }

        [Test]
        public async Task ConfirmUser_ConfirmedUser_ShouldNotConfirmUser()
        {
            await roleManager.CreateAsync(new IdentityRole("Student"));
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
            await roleManager.CreateAsync(new IdentityRole("Principal"));

            EdumanUser user = new EdumanUser
            {
                UserName = "studentName",
                FirstName = "Student",
                LastName = "TestName",
                IsConfirmed = true,
                Id = "TestStudentId",
                School = "TestSchool"
            };

            EdumanUser principal = new EdumanUser
            {
                UserName = "principalName",
                FirstName = "Principal",
                LastName = "TestName",
                IsConfirmed = true,
                Id = "TestPrincipalId",
                School = "TestSchool"
            };

            this.userManager.CreateAsync(user).GetAwaiter();
            this.userManager.CreateAsync(principal).GetAwaiter();

            userManager.AddToRoleAsync(user, "Student").GetAwaiter();
            userManager.AddToRoleAsync(principal, "Principal").GetAwaiter();

            this.Context.SaveChanges();



            // Assert
            var ex = Assert.Throws<Exception>(() => accountService.ConfirmUser("TestStudentId"));

            Assert.AreEqual(ex.Message, "The User is non-existent");

        }
    }
}
