using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduman.Data;
using Eduman.Models;
using Eduman.Models.BindingModels;
using Eduman.Services;
using Eduman.Services.Contracts;
using Eduman.Tests.Eduman.Services.Tests.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Eduman.Tests.Eduman.Services.Tests.Absence
{
    [TestFixture]
    public class AbsenceServiceTests : BaseServiceTest
    {
        private UserManager<EdumanUser> userManager => this.Provider.GetRequiredService<UserManager<EdumanUser>>();
        private IAbsenceService absenceService => this.Provider.GetRequiredService<IAbsenceService>();
        private RoleManager<IdentityRole> roleManager => this.Provider.GetRequiredService<RoleManager<IdentityRole>>();
        
        [Test]
        public async Task Create_WithValidData_ShouldIncludeIntoDatabase()
        {
            await roleManager.CreateAsync(new IdentityRole("Student"));
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
            await roleManager.CreateAsync(new IdentityRole("Principal"));

            EdumanUser student = new EdumanUser
            {
                UserName = "studentName",
                FirstName = "Student",
                LastName = "TestName",
                IsConfirmed = true,
                Id = "TestStudentId"
            };

            EdumanUser teacher = new EdumanUser
            {
                UserName = "teacherName",
                IsConfirmed = true,
                Id = "TestTeacherId"
            };

            this.userManager.CreateAsync(student).GetAwaiter();
            this.userManager.CreateAsync(teacher).GetAwaiter();

            userManager.AddToRoleAsync(student, "Student").GetAwaiter();
            userManager.AddToRoleAsync(teacher, "Teacher").GetAwaiter();

            this.Context.SaveChanges();
            
            CreateAbsenceBindingModel model = new CreateAbsenceBindingModel()
            {
                StudentFirstName = "Student",
                DateAbsent = DateTime.Now,
                StudentLastName = "TestName",
                Subject = "Maths"
            };

            await absenceService.CreateAsync(model, "teacherName");
            
            var count = (absenceService.GetAllAsync("TestStudentId").GetAwaiter().GetResult()).Count;
            // Assert
            Assert.AreEqual(1, count);
        }
        [Test]
        public async Task Create_WithNonExistentUser_ShouldNotIncludeIntoDatabase()
        {
            await roleManager.CreateAsync(new IdentityRole("Student"));
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
            await roleManager.CreateAsync(new IdentityRole("Principal"));

            
            EdumanUser teacher = new EdumanUser
            {
                UserName = "teacherName",
                IsConfirmed = true,
                Id = "TestTeacherId"
            };
            
            this.userManager.CreateAsync(teacher).GetAwaiter();
            
            userManager.AddToRoleAsync(teacher, "Teacher").GetAwaiter();

            this.Context.SaveChanges();
            
            CreateAbsenceBindingModel model = new CreateAbsenceBindingModel()
            {
                StudentFirstName = "Student",
                DateAbsent = DateTime.Now,
                StudentLastName = "TestName",
                Subject = "Maths"
            };
            
            // Assert
            var ex = Assert.ThrowsAsync<Exception>(() => absenceService.CreateAsync(model, "teacherName"));

            Assert.AreEqual(ex.Message, "The User is either non-existent or is not a student");
        }
        [Test]
        public async Task Create_WithNonStudentUser_ShouldNotIncludeIntoDatabase()
        {
            await roleManager.CreateAsync(new IdentityRole("Student"));
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
            await roleManager.CreateAsync(new IdentityRole("Principal"));

            EdumanUser student = new EdumanUser
            {
                UserName = "studentName",
                FirstName = "Student",
                LastName = "TestName",
                IsConfirmed = true,
                Id = "TestStudentId"
            };

            EdumanUser teacher = new EdumanUser
            {
                UserName = "teacherName",
                IsConfirmed = true,
                Id = "TestTeacherId"
            };

            this.userManager.CreateAsync(student).GetAwaiter();
            this.userManager.CreateAsync(teacher).GetAwaiter();

            userManager.AddToRoleAsync(student, "Principal").GetAwaiter();
            userManager.AddToRoleAsync(teacher, "Teacher").GetAwaiter();

            this.Context.SaveChanges();
            
            CreateAbsenceBindingModel model = new CreateAbsenceBindingModel()
            {
                StudentFirstName = "Student",
                DateAbsent = DateTime.Now,
                StudentLastName = "TestName",
                Subject = "Maths"
            };

            // Assert
            var ex = Assert.ThrowsAsync<Exception>(() => absenceService.CreateAsync(model, "teacherName"));

            Assert.AreEqual(ex.Message, "The User is either non-existent or is not a student");
        }

        [Test]
        public async Task All_WithValidData_ShouldReturnCorrectData()
        {
            await roleManager.CreateAsync(new IdentityRole("Student"));
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
            await roleManager.CreateAsync(new IdentityRole("Principal"));

            EdumanUser student = new EdumanUser
            {
                UserName = "studentName",
                FirstName = "Student",
                LastName = "TestName",
                IsConfirmed = true,
                Id = "TestStudentId"
            };

            EdumanUser teacher = new EdumanUser
            {
                UserName = "teacherName",
                IsConfirmed = true,
                Id = "TestTeacherId"
            };

            this.userManager.CreateAsync(student).GetAwaiter();
            this.userManager.CreateAsync(teacher).GetAwaiter();

            userManager.AddToRoleAsync(student, "Student").GetAwaiter();
            userManager.AddToRoleAsync(teacher, "Teacher").GetAwaiter();

            this.Context.SaveChanges();


            CreateAbsenceBindingModel model = new CreateAbsenceBindingModel()
            {
                StudentFirstName = "Student",
                DateAbsent = DateTime.Now,
                StudentLastName = "TestName",
                Subject = "Maths"
            };

            await absenceService.CreateAsync(model, "teacherName");

            var count = (absenceService.GetAllAsync("TestStudentId").GetAwaiter().GetResult()).Count;
            var absence = absenceService.GetAllAsync("TestStudentId").GetAwaiter().GetResult().FirstOrDefault();
            // Assert
            Assert.AreEqual(1, count);
            Assert.AreEqual("Maths", absence.Subject);
            Assert.AreEqual("studentName", absence.StudentName);
        }

        [Test]
        public async Task All_DifferentUser_ShouldReturnNoData()
        {
            await roleManager.CreateAsync(new IdentityRole("Student"));
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
            await roleManager.CreateAsync(new IdentityRole("Principal"));

            EdumanUser student = new EdumanUser
            {
                UserName = "studentName",
                FirstName = "Student",
                LastName = "TestName",
                IsConfirmed = true,
                Id = "TestStudentId"
            };
            EdumanUser anotherStudent = new EdumanUser
            {
                UserName = "studentName1",
                FirstName = "Student1",
                LastName = "TestName1",
                IsConfirmed = true,
                Id = "TestStudentId1"
            };

            EdumanUser teacher = new EdumanUser
            {
                UserName = "teacherName",
                IsConfirmed = true,
                Id = "TestTeacherId"
            };

            this.userManager.CreateAsync(student).GetAwaiter();
            this.userManager.CreateAsync(anotherStudent).GetAwaiter();
            this.userManager.CreateAsync(teacher).GetAwaiter();

            userManager.AddToRoleAsync(student, "Student").GetAwaiter();
            userManager.AddToRoleAsync(anotherStudent, "Student").GetAwaiter();
            userManager.AddToRoleAsync(teacher, "Teacher").GetAwaiter();

            this.Context.SaveChanges();
            
            CreateAbsenceBindingModel model = new CreateAbsenceBindingModel()
            {
                StudentFirstName = "Student1",
                DateAbsent = DateTime.Now,
                StudentLastName = "TestName1",
                Subject = "Maths"
            };

            await absenceService.CreateAsync(model, "teacherName");

            var count = (absenceService.GetAllAsync("TestStudentId").GetAwaiter().GetResult()).Count;
            var absence = absenceService.GetAllAsync("TestStudentId").GetAwaiter().GetResult().FirstOrDefault();
            // Assert
            Assert.AreEqual(0, count);
        }
        
    }
}
