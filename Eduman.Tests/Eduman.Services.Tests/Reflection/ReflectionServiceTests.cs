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

namespace Eduman.Tests.Eduman.Services.Tests.Reflection
{
    public class ReflectionServiceTests : BaseServiceTest
    {
        private UserManager<EdumanUser> userManager => this.Provider.GetRequiredService<UserManager<EdumanUser>>();
        private IReflectionService reflectionService => this.Provider.GetRequiredService<IReflectionService>();
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

            CreateReflectionBindingModel model = new CreateReflectionBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestReflectionDescription",
                IsCompliment = true
            };

            await reflectionService.CreateAsync(model, "teacherName");

            var count = (reflectionService.GetAllComplimentsAsync("TestStudentId").GetAwaiter().GetResult()).Count + (reflectionService.GetAllCriticismsAsync("TestStudentId").GetAwaiter().GetResult()).Count;
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

            CreateReflectionBindingModel model = new CreateReflectionBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestReflectionDescription",
                IsCompliment = true
            };

            // Assert
            var ex = Assert.ThrowsAsync<Exception>(() => reflectionService .CreateAsync(model, "teacherName"));

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

            CreateReflectionBindingModel model = new CreateReflectionBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestReflectionDescription",
                IsCompliment = true
            };

            // Assert
            var ex = Assert.ThrowsAsync<Exception>(() => reflectionService.CreateAsync(model, "teacherName"));

            Assert.AreEqual(ex.Message, "The User is either non-existent or is not a student");
        }

        [Test]
        public async Task AllCompliments_WithValidData_ShouldReturnCorrectData()
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


            CreateReflectionBindingModel compliment = new CreateReflectionBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestReflectionDescription",
                IsCompliment = true
            };

            CreateReflectionBindingModel criticism = new CreateReflectionBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestReflectionDescription",
                IsCompliment = false
            };

            await reflectionService.CreateAsync(compliment, "teacherName");
            await reflectionService.CreateAsync(criticism, "teacherName");

            var count = (reflectionService.GetAllComplimentsAsync("TestTeacherId").GetAwaiter().GetResult()).Count;
            var reflectionResult = reflectionService.GetAllComplimentsAsync("TestTeacherId").GetAwaiter().GetResult().FirstOrDefault();
            // Assert
            Assert.AreEqual(1, count);
            Assert.AreEqual("TestReflectionDescription", reflectionResult.Description);
            Assert.AreEqual("studentName", reflectionResult.StudentUsername);
            Assert.AreEqual("teacherName", reflectionResult.TeacherUsername);
        }

        [Test]
        public async Task AllCriticism_WithValidData_ShouldReturnCorrectData()
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


            CreateReflectionBindingModel compliment = new CreateReflectionBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestReflectionDescription",
                IsCompliment = true
            };

            CreateReflectionBindingModel criticism = new CreateReflectionBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestReflectionDescription",
                IsCompliment = false
            };

            await reflectionService.CreateAsync(compliment, "teacherName");
            await reflectionService.CreateAsync(criticism, "teacherName");

            var count = (reflectionService.GetAllCriticismsAsync("TestTeacherId").GetAwaiter().GetResult()).Count;
            var reflectionResult = reflectionService.GetAllCriticismsAsync("TestTeacherId").GetAwaiter().GetResult().FirstOrDefault();
            // Assert
            Assert.AreEqual(1, count);
            Assert.AreEqual("TestReflectionDescription", reflectionResult.Description);
            Assert.AreEqual("studentName", reflectionResult.StudentUsername);
            Assert.AreEqual("teacherName", reflectionResult.TeacherUsername);
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

            CreateReflectionBindingModel model = new CreateReflectionBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestReflectionDescription",
                IsCompliment = true
            };

            await reflectionService.CreateAsync(model, "teacherName");

            var count = (reflectionService.GetAllComplimentsAsync("TestStudentId1").GetAwaiter().GetResult()).Count;
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

            CreateReflectionBindingModel model = new CreateReflectionBindingModel()
            {
                StudentFirstName = "Student",
                StudentLastName = "TestName",
                Description = "TestReflectionDescription",
                IsCompliment = true
            };

            await reflectionService.CreateAsync(model, "teacherName");

            var id = (reflectionService.GetAllComplimentsAsync("TestStudentId").GetAwaiter().GetResult().FirstOrDefault()).Id;

            var reflectionDetails = await reflectionService.GetReflectionDetails(id);
            // Assert
            Assert.AreEqual("Student", reflectionDetails.StudentFirstName);
            Assert.AreEqual("TestName", reflectionDetails.StudentLastName);
            Assert.AreEqual("TestReflectionDescription", reflectionDetails.Description);
            Assert.AreEqual("TeacherFirstName", reflectionDetails.TeacherFirstName);
            Assert.AreEqual("TeacherLastName", reflectionDetails.TeacherLastName);
            Assert.AreEqual(true, reflectionDetails.IsCompliment);
        }

    }
}
