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

namespace Eduman.Services
{
    public class GradeService : DataService, IGradeService
    {
        private UserManager<EdumanUser> userManager;

        public GradeService(EdumanDbContext context, UserManager<EdumanUser> userManager) : base(context)
        {
            this.userManager = userManager;
        }

        public async Task CreateAsync(CreateGradeBindingModel gradeBindingModel, string teacherName)
        {
            EdumanUser Student = this.context.Users.FirstOrDefault(u =>
                u.FirstName == gradeBindingModel.StudentFirstName && u.LastName == gradeBindingModel.StudentLastName &&
                u.IsConfirmed);

            EdumanUser Teacher =
                this.context.Users.FirstOrDefault(u => u.UserName == teacherName);
            if (Student == null || !(await userManager.IsInRoleAsync(Student, "Student")))
            {
                throw new Exception("The User is either non-existent or is not a student");
            }

            Grade gradeModel = new Grade
            {
                DateCreated = DateTime.Now,
                Description = gradeBindingModel.Description,
                StudentId = Student.Id,
                Subject = gradeBindingModel.Subject,
                TeacherId = Teacher.Id,
                Value = gradeBindingModel.Value
            };

            this.context.Grades.Add(gradeModel);
            this.context.SaveChanges();
        }

        public async Task<List<AllGradesViewModel>> GetAllAsync(string UserId)
        {
            EdumanUser user = await this.context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            List<AllGradesViewModel> grades = new List<AllGradesViewModel>();
            if (await userManager.IsInRoleAsync(user, "Teacher"))
            {

                var resultList = this.context.Grades.Where(a => a.TeacherId == UserId).ToList();
                foreach (var currentGrade in resultList)
                {
                    AllGradesViewModel temp = new AllGradesViewModel 
                    {
                        Value = currentGrade.Value,
                        Id = currentGrade.Id,
                        Subject = currentGrade.Subject
                    };
                    grades.Add(temp);

                }
            }
            else if (await userManager.IsInRoleAsync(user, "Student"))
            {

                var resultList = this.context.Grades.Where(e => e.StudentId == UserId).ToList();
                foreach (var currentGrade in resultList)
                {
                    AllGradesViewModel temp = new AllGradesViewModel
                    {
                        Value = currentGrade.Value,
                        Id = currentGrade.Id,
                        Subject = currentGrade.Subject
                    };
                    grades.Add(temp);

                }
            }

            return grades;
        }

        public async Task<GradeDetailsViewModel> GetGradeDetails(string id)
        {
            var gradeModel = this.context.Grades.FirstOrDefault(e => e.Id == id);
            EdumanUser student = await userManager.FindByIdAsync(gradeModel.StudentId);
            EdumanUser teacher = await userManager.FindByIdAsync(gradeModel.TeacherId);
            return new GradeDetailsViewModel
            {
                Description = gradeModel.Description,
                StudentFirstName = student.FirstName,
                StudentLastName = student.LastName,
                TeacherFirstName = teacher.FirstName,
                TeacherLastName = teacher.LastName,
                DateCreated = gradeModel.DateCreated,
                Subject = gradeModel.Subject,
                Value = gradeModel.Value
            };
        }
    }
}
