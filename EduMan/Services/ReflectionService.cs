using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Data;
using Eduman.Models;
using Eduman.Models.BindingModels;
using Eduman.Models.ViewModels;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace Eduman.Services
{
    public class ReflectionService : DataService , IReflectionService
    {
        private UserManager<EdumanUser> userManager;

        public ReflectionService(EdumanDbContext context, UserManager<EdumanUser> userManager) : base(context)
        {
            this.userManager = userManager;
        }

        public async Task CreateAsync(CreateReflectionBindingModel reflectionBindingModel, string teacherName)
        {
            EdumanUser Student = this.context.Users.FirstOrDefault(u =>
                u.FirstName == reflectionBindingModel.StudentFirstName && u.LastName == reflectionBindingModel.StudentLastName &&
                u.IsConfirmed);

            EdumanUser Teacher =
                this.context.Users.FirstOrDefault(u => u.UserName == teacherName);
            if (Student == null || !(await userManager.IsInRoleAsync(Student, "Student")))
            {
                throw new Exception("The User is either non-existent or is not a student");
            }

            Reflection reflectionModel = new Reflection
            {
                DateCreated = DateTime.Now,
                Description = reflectionBindingModel.Description,
                StudentId = Student.Id,
                TeacherId = Teacher.Id,
                IsCompliment = reflectionBindingModel.IsCompliment

            };

            this.context.Reflections.Add(reflectionModel);
            this.context.SaveChanges();
        }

        public async Task<List<AllReflectionsViewModel>> GetAllComplimentsAsync(string UserId)
        {
            EdumanUser user = await this.context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            List<AllReflectionsViewModel> reflections = new List<AllReflectionsViewModel>();
            if (await userManager.IsInRoleAsync(user, "Teacher"))
            {

                var resultList = this.context.Reflections.Where(r => r.TeacherId == UserId && r.IsCompliment).ToList();
                foreach (var currentReflection in resultList)
                {
                    AllReflectionsViewModel temp = new AllReflectionsViewModel
                    {
                        Id = currentReflection.Id,
                        DateCreated = currentReflection.DateCreated,
                        Description = currentReflection.Description,
                        StudentUsername = this.context.Users.FirstOrDefault(u => u.Id == currentReflection.StudentId).UserName,
                        TeacherUsername = user.UserName

                    };
                    reflections.Add(temp);

                }
            }
            else if (await userManager.IsInRoleAsync(user, "Student"))
            {

                var resultList = this.context.Reflections.Where(r => r.StudentId == UserId && r.IsCompliment).ToList();
                foreach (var currentReflection in resultList)
                {
                    AllReflectionsViewModel temp = new AllReflectionsViewModel
                    {
                        Id = currentReflection.Id,
                        DateCreated = currentReflection.DateCreated,
                        Description = currentReflection.Description,
                        StudentUsername = this.context.Users.FirstOrDefault(u => u.Id == currentReflection.StudentId).UserName,
                        TeacherUsername = user.UserName

                    };
                    reflections.Add(temp);

                }
            }

            return reflections;
        }

        public async Task<List<AllReflectionsViewModel>> GetAllCriticismsAsync(string UserId)
        {
            EdumanUser user = await this.context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            List<AllReflectionsViewModel> reflections = new List<AllReflectionsViewModel>();
            if (await userManager.IsInRoleAsync(user, "Teacher"))
            {

                var resultList = this.context.Reflections.Where(r => r.TeacherId == UserId && !r.IsCompliment).ToList();
                foreach (var currentReflection in resultList)
                {
                    AllReflectionsViewModel temp = new AllReflectionsViewModel
                    {
                        Id = currentReflection.Id,
                        DateCreated = currentReflection.DateCreated,
                        Description = currentReflection.Description,
                        StudentUsername = this.context.Users.FirstOrDefault(u => u.Id == currentReflection.StudentId).UserName,
                        TeacherUsername = user.UserName

                    };
                    reflections.Add(temp);

                }
            }
            else if (await userManager.IsInRoleAsync(user, "Student"))
            {

                var resultList = this.context.Reflections.Where(r => r.StudentId == UserId && !r.IsCompliment).ToList();
                foreach (var currentReflection in resultList)
                {
                    AllReflectionsViewModel temp = new AllReflectionsViewModel
                    {
                        Id = currentReflection.Id,
                        DateCreated = currentReflection.DateCreated,
                        Description = currentReflection.Description,
                        StudentUsername = this.context.Users.FirstOrDefault(u => u.Id == currentReflection.StudentId).UserName,
                        TeacherUsername = user.UserName

                    };
                    reflections.Add(temp);

                }
            }

            return reflections;
        }


        public async Task<ReflectionDetailsViewModel> GetReflectionDetails(string id)
        {
            var reflectionModel = this.context.Reflections.FirstOrDefault(e => e.Id == id);
            EdumanUser student = await userManager.FindByIdAsync(reflectionModel.StudentId);
            EdumanUser teacher = await userManager.FindByIdAsync(reflectionModel.TeacherId);
            return new ReflectionDetailsViewModel
            {
                Description = reflectionModel.Description,
                StudentFirstName = student.FirstName,
                StudentLastName = student.LastName,
                TeacherFirstName = teacher.FirstName,
                TeacherLastName = teacher.LastName,
                DateCreated = reflectionModel.DateCreated,
                IsCompliment = reflectionModel.IsCompliment,
            };
        }
    }
}
