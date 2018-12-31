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
    public class ReflectionController : Controller
    {
        private IReflectionService reflectionService;
        private UserManager<EdumanUser> userManager { get; set; }
        public ReflectionController(UserManager<EdumanUser> userManager, IReflectionService reflectionService)
        {
            this.userManager = userManager;
            this.reflectionService = reflectionService;
        }


        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(CreateReflectionBindingModel createReflectionBindingModel)
        {
            try
            {
                await reflectionService.CreateAsync(createReflectionBindingModel, this.User.Identity.Name);
            }
            catch (Exception e)
            {
                if (e.Message == "The User is either non-existent or is not a student") return this.View("~/Views/Shared/NonExistentStudentPage.cshtml");
            }
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "Student, Teacher")]
        public async Task<IActionResult> AllCompliments()
        {
            return this.View(await reflectionService.GetAllComplimentsAsync(this.userManager.GetUserId(this.User)));
        }

        [HttpGet]
        [Authorize(Roles="Student, Teacher")]
        public async Task<IActionResult> AllCriticisms()
        {
            return this.View(await reflectionService.GetAllCriticismsAsync(this.userManager.GetUserId(this.User)));
        }

        [HttpGet]
        [Authorize(Roles = "Student, Teacher")]
        public async Task<IActionResult> Details(string id)
        {
            return this.View(await reflectionService.GetReflectionDetails(id));
        }
    }
}
