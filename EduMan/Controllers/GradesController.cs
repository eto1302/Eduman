using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models;
using Eduman.Models.BindingModels;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eduman.Controllers
{
    public class GradesController : Controller
    {
        private IGradeService gradeService;
        private UserManager<EdumanUser> userManager { get; set; }
        public GradesController(UserManager<EdumanUser> userManager, IGradeService gradeService)
        {
            this.userManager = userManager;
            this.gradeService = gradeService;
        }


        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(CreateGradeBindingModel createGradeBindingModel)
        {
            try
            {
                await gradeService.CreateAsync(createGradeBindingModel, this.User.Identity.Name);
            }
            catch (Exception e)
            {
                if (e.Message == "The User is either non-existent or is not a student") return this.View("~/Views/Shared/NonExistentStudentPage.cshtml");
            }
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "Teacher, Student")]
        public async Task<IActionResult> All()
        {
            return this.View(await gradeService.GetAllAsync(this.userManager.GetUserId(this.User)));
        }


        [HttpGet]
        [Authorize(Roles = "Teacher, Student")]
        public async Task<IActionResult> Details(string id)
        {
            return this.View(await gradeService.GetGradeDetails(id));
        }
    }
}
