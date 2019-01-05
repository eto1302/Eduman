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

namespace Eduman.Tests.Eduman.Services.Tests.Fee
{
    public class FeeServiceTests : BaseServiceTest
    {
        private UserManager<EdumanUser> userManager => this.Provider.GetRequiredService<UserManager<EdumanUser>>();
        private IFeeService feeService => this.Provider.GetRequiredService<IFeeService>();
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

            CreateFeeBindingModel model = new CreateFeeBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestFeeDescription",
                Cost = 27,
                DueDate = DateTime.Now
            };

            await feeService.CreateAsync(model, "teacherName");

            var count = (feeService.GetAllAsync("TestStudentId").GetAwaiter().GetResult()).Count;
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

            CreateFeeBindingModel model = new CreateFeeBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestFeeDescription",
                Cost = 27,
                DueDate = DateTime.Now
            };

            // Assert
            var ex = Assert.ThrowsAsync<Exception>(() => feeService.CreateAsync(model, "teacherName"));

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

            CreateFeeBindingModel model = new CreateFeeBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestFeeDescription",
                Cost = 27,
                DueDate = DateTime.Now
            };

            // Assert
            var ex = Assert.ThrowsAsync<Exception>(() => feeService.CreateAsync(model, "teacherName"));

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


            CreateFeeBindingModel model = new CreateFeeBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestFeeDescription",
                Cost = 27,
                DueDate = DateTime.Now
            };

            await feeService.CreateAsync(model, "teacherName");

            var count = (feeService.GetAllAsync("TestStudentId").GetAwaiter().GetResult()).Count;
            var feeResult = feeService.GetAllAsync("TestStudentId").GetAwaiter().GetResult().FirstOrDefault();
            // Assert
            Assert.AreEqual(1, count);
            Assert.AreEqual("studentName", feeResult.StudentUsername);
            Assert.AreEqual("teacherName", feeResult.TeacherUsername);
            Assert.AreEqual(27, feeResult.Cost);
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

            CreateFeeBindingModel model = new CreateFeeBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestFeeDescription",
                Cost = 27,
                DueDate = DateTime.Now
            };

            await feeService.CreateAsync(model, "teacherName");

            var count = (feeService.GetAllAsync("TestStudentId1").GetAwaiter().GetResult()).Count;
            // Assert
            Assert.AreEqual(0, count);
        }

        [Test]
        public async Task Details_DifferentUser_ShouldReturnNoData()
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
                Id = "TestStudentId",
                School = "TestSchool"
            };

            EdumanUser teacher = new EdumanUser
            {
                UserName = "teacherName",
                IsConfirmed = true,
                Id = "TestTeacherId",
                FirstName = "TeacherFirstName",
                LastName = "TeacherLastName"
            };

            this.userManager.CreateAsync(student).GetAwaiter();
            this.userManager.CreateAsync(teacher).GetAwaiter();

            userManager.AddToRoleAsync(student, "Student").GetAwaiter();
            userManager.AddToRoleAsync(teacher, "Teacher").GetAwaiter();

            this.Context.SaveChanges();

            CreateFeeBindingModel model = new CreateFeeBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestFeeDescription",
                Cost = 27,
                DueDate = DateTime.Now
            };

            await feeService.CreateAsync(model, "teacherName");

            var id = (feeService.GetAllAsync("TestStudentId").GetAwaiter().GetResult().FirstOrDefault()).Id;

            var feeDetails = await feeService.GetFeeDetails(id);
            // Assert
            Assert.AreEqual("Student", feeDetails.StudentFirstName);
            Assert.AreEqual("TestName", feeDetails.StudentLastName);
            Assert.AreEqual("TestFeeDescription", feeDetails.Description);
            Assert.AreEqual("TestSchool", feeDetails.School);
            Assert.AreEqual("TeacherFirstName", feeDetails.TeacherFirstName);
            Assert.AreEqual("TeacherLastName", feeDetails.TeacherLastName);
            Assert.AreEqual(27, feeDetails.Cost);
        }


    }
}
