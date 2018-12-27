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
    public class EventService : DataService, IEventService
    {
        private UserManager<EdumanUser> userManager { get; set; }
        public EventService(EdumanDbContext context, UserManager<EdumanUser> userManager) : base(context)
        {
            this.userManager = userManager;
        }

        public async Task CreateAsync(CreateEventBindingModel eventBindingModel, string teacherName)
        {
            EdumanUser Student = this.context.Users.FirstOrDefault(u =>
                u.FirstName == eventBindingModel.StudentFirstName && u.LastName == eventBindingModel.StudentLastName && u.IsConfirmed);

            EdumanUser Teacher =
                this.context.Users.FirstOrDefault(u => u.UserName == teacherName);
            if (Student == null || !(await userManager.IsInRoleAsync(Student, "Student")))
            {
                throw new Exception("The User is either non-existent or is not a student");
            }

            Event eventModel = new Event
            {
                Description = eventBindingModel.Description,
                EventDate = eventBindingModel.EventDate,
                StudentId = Student.Id,
                TeacherId = Teacher.Id,
                Type = eventBindingModel.Type
            };

            this.context.Events.Add(eventModel);
            this.context.SaveChanges();
        }

        public async Task<List<AllEventsViewModel>> GetAllAsync(string UserId)
        {
            EdumanUser user = await this.context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            List<AllEventsViewModel> events = new List<AllEventsViewModel>();
            if (await userManager.IsInRoleAsync(user, "Teacher"))
            {

                var resultList = this.context.Events.Where(a => a.TeacherId == UserId).ToList();
                foreach (var currentEvent in resultList)
                {
                    AllEventsViewModel temp = new AllEventsViewModel
                    {
                        StudentUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentEvent.StudentId).UserName,
                        TeacherUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentEvent.TeacherId).UserName,
                        EventDate = currentEvent.EventDate,
                        Type = currentEvent.Type,
                        Id = currentEvent.Id
                    };
                    events.Add(temp);

                }
            }
            else if (await userManager.IsInRoleAsync(user, "Principal"))
            {
                var resultList = this.context.Events.Where(
                    e => this.context.Users
                                     .FirstOrDefault(u => u.Id == e.StudentId).School == user.School).ToList();

                foreach (var currentEvent in resultList)
                {
                    AllEventsViewModel temp = new AllEventsViewModel
                    {
                        StudentUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentEvent.StudentId).UserName,
                        TeacherUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentEvent.TeacherId).UserName,
                        Id = currentEvent.Id,
                        EventDate = currentEvent.EventDate,
                        Type = currentEvent.Type
                    };
                    events.Add(temp);

                }
            }
            else if (await userManager.IsInRoleAsync(user, "Student"))
            {

                var resultList = this.context.Events.Where(e => e.StudentId == UserId).ToList();
                foreach (var currentEvent in resultList)
                {
                    AllEventsViewModel temp = new AllEventsViewModel
                    {
                        StudentUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentEvent.StudentId).UserName,
                        TeacherUsername = this.context.Users
                            .FirstOrDefault(u => u.Id == currentEvent.TeacherId).UserName,
                        Id = currentEvent.Id,
                        EventDate = currentEvent.EventDate,
                        Type = currentEvent.Type
                    };
                    events.Add(temp);

                }
            }
            return events;
        }

        public async Task<EventDetailsViewModel> GetEventDetails(string id)
        {

            var eventModel = this.context.Events.FirstOrDefault(e => e.Id == id);
            EdumanUser student = await userManager.FindByIdAsync(eventModel.StudentId);
            EdumanUser teacher = await userManager.FindByIdAsync(eventModel.TeacherId);
            return new EventDetailsViewModel
            {
                Description = eventModel.Description,
                EventDate = eventModel.EventDate,
                StudentFirstName = student.FirstName,
                StudentLastName = student.LastName,
                School = student.School,
                TeacherFirstName = teacher.FirstName,
                TeacherLastName = teacher.LastName,
                Type = eventModel.Type
            };

        }
    }
}
