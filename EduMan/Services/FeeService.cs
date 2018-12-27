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
    public class FeeService : DataService, IFeeService
    {
        private UserManager<EdumanUser> userManager { get; set; }

        public FeeService(EdumanDbContext context, UserManager<EdumanUser> userManager) : base(context)
        {
            this.userManager = userManager;
        }

        public async Task CreateAsync(CreateFeeBindingModel feeBindingModel, string teacherName)
        {
            EdumanUser Student = this.context.Users.FirstOrDefault(u =>
                u.FirstName == feeBindingModel.StudentFirstName && u.LastName == feeBindingModel.StudentLastName &&
                u.IsConfirmed);

            EdumanUser Teacher =
                this.context.Users.FirstOrDefault(u => u.UserName == teacherName);
            if (Student == null || !(await userManager.IsInRoleAsync(Student, "Student")))
            {
                throw new Exception("The User is either non-existent or is not a student");
            }

            Fee feeModel = new Fee
            {
                Description = feeBindingModel.Description,
                DueDate = feeBindingModel.DueDate,
                StudentId = Student.Id,
                TeacherId = Teacher.Id,
                Cost = feeBindingModel.Cost
            };

            this.context.Fees.Add(feeModel);
            this.context.SaveChanges();
        }

        public async Task<List<AllFeesViewModel>> GetAllAsync(string UserId)
        {
            EdumanUser user = await this.context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            List<AllFeesViewModel> fees = new List<AllFeesViewModel>();
            if (await userManager.IsInRoleAsync(user, "Teacher"))
            {

                var resultList = this.context.Fees.Where(a => a.TeacherId == UserId).ToList();
                foreach (var currentFee in resultList)
                {
                    AllFeesViewModel temp = new AllFeesViewModel
                    {
                        StudentUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentFee.StudentId).UserName,
                        TeacherUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentFee.TeacherId).UserName,
                        DueDate = currentFee.DueDate,
                        Cost = currentFee.Cost,
                        Id = currentFee.Id
                    };
                    fees.Add(temp);

                }
            }
            else if (await userManager.IsInRoleAsync(user, "Principal"))
            {
                var resultList = this.context.Fees.Where(
                    e => this.context.Users
                             .FirstOrDefault(u => u.Id == e.StudentId).School == user.School).ToList();

                foreach (var currentFee in resultList)
                {
                    AllFeesViewModel temp = new AllFeesViewModel
                    {
                        StudentUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentFee.StudentId).UserName,
                        TeacherUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentFee.TeacherId).UserName,
                        DueDate = currentFee.DueDate,
                        Cost = currentFee.Cost,
                        Id = currentFee.Id
                    };
                    fees.Add(temp);

                }
            }
            else if (await userManager.IsInRoleAsync(user, "Student"))
            {

                var resultList = this.context.Fees.Where(e => e.StudentId == UserId).ToList();
                foreach (var currentFee in resultList)
                {
                    AllFeesViewModel temp = new AllFeesViewModel
                    {
                        StudentUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentFee.StudentId).UserName,
                        TeacherUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentFee.TeacherId).UserName,
                        DueDate = currentFee.DueDate,
                        Cost = currentFee.Cost,
                        Id = currentFee.Id
                    };
                    fees.Add(temp);

                }
            }

            return fees;
        }

        public async Task<FeeDetailsViewModel> GetFeeDetails(string id)
        {

            var feeModel = this.context.Fees.FirstOrDefault(e => e.Id == id);
            EdumanUser student = await userManager.FindByIdAsync(feeModel.StudentId);
            EdumanUser teacher = await userManager.FindByIdAsync(feeModel.TeacherId);
            return new FeeDetailsViewModel
            {
                Description = feeModel.Description,
                DueDate = feeModel.DueDate,
                StudentFirstName = student.FirstName,
                StudentLastName = student.LastName,
                School = student.School,
                TeacherFirstName = teacher.FirstName,
                TeacherLastName = teacher.LastName,
                Cost = feeModel.Cost
            };

        }
    }
}
