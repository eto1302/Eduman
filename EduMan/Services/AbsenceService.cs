using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eduman.Data;
using Eduman.Models;
using System.Web;
using Eduman.Models.BindingModels;
using Eduman.Models.ViewModels;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eduman.Services
{
    public class AbsenceService : DataService, IAbsenceService
    {
        private UserManager<EdumanUser> userManager { get; set; }
        public AbsenceService(EdumanDbContext context, UserManager<EdumanUser> userManager) : base(context)
        {
            this.userManager = userManager;
        }

        public async Task CreateAsync(CreateAbsenceBindingModel absenceModel, string teacherName)
        {
            EdumanUser Student = this.context.Users.FirstOrDefault(u =>
                u.FirstName == absenceModel.StudentFirstName && u.LastName == absenceModel.StudentLastName && u.IsConfirmed);

            EdumanUser Teacher =
                this.context.Users.FirstOrDefault(u => u.UserName == teacherName);
            if (Student == null || !(await userManager.IsInRoleAsync(Student, "Student")))
            {
                throw new Exception("The User is either non-existent or is not a student");
            }

            Absence absence = new Absence
            {
                DateAbsent = absenceModel.DateAbsent,
                StudentId = Student.Id,
                Subject = absenceModel.Subject,
                TeacherId = Teacher.Id
            };

            this.context.Absences.Add(absence);
            this.context.SaveChanges();

        }

        public async Task<List<AllAbsencesViewModel>> GetAllAsync(string UserId)
        {
            EdumanUser user = await this.context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            List<AllAbsencesViewModel> absences = new List<AllAbsencesViewModel>();
            if (await userManager.IsInRoleAsync(user, "Teacher"))
            {

                var resultList = this.context.Absences.Where(a => a.TeacherId == UserId).ToList();
                foreach (var absence in resultList)
                {
                    AllAbsencesViewModel temp = new AllAbsencesViewModel
                    {
                        DateAbsent = absence.DateAbsent,
                        StudentName = this.context.Users
                            .FirstOrDefault(u => u.Id == absence.StudentId).UserName,
                        Subject = absence.Subject,
                        TeacherName = this.context.Users
                            .FirstOrDefault(u => u.Id == absence.TeacherId).UserName
                    };
                    absences.Add(temp);

                }
            }
            else if (await userManager.IsInRoleAsync(user, "Principal"))
            {
                var resultList = this.context.Absences.Where(
                    a => this.context.Users
                                     .FirstOrDefault(u => u.Id == a.StudentId).School == user.School).ToList();

                foreach (var absence in resultList)
                {
                    AllAbsencesViewModel temp = new AllAbsencesViewModel
                    {
                        DateAbsent = absence.DateAbsent,
                        StudentName = this.context.Users
                                                  .FirstOrDefault(u => u.Id == absence.StudentId).UserName,
                        Subject = absence.Subject,
                        TeacherName = this.context.Users
                                                  .FirstOrDefault(u => u.Id == absence.TeacherId).UserName
                    };
                    absences.Add(temp);
                }
            }
            else if (await userManager.IsInRoleAsync(user, "Student"))
            {

                var resultList = this.context.Absences.Where(a => a.StudentId == UserId).ToList();
                foreach (var absence in resultList)
                {
                    AllAbsencesViewModel temp = new AllAbsencesViewModel
                    {
                        DateAbsent = absence.DateAbsent,
                        StudentName = this.context.Users
                            .FirstOrDefault(u => u.Id == absence.StudentId).UserName,
                        Subject = absence.Subject,
                        TeacherName = this.context.Users
                            .FirstOrDefault(u => u.Id == absence.TeacherId).UserName
                    };
                    absences.Add(temp);

                }
            }
            return absences;
        }
    }
}
