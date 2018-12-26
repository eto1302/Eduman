using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eduman.Models;
using Eduman.Models.BindingModels;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eduman.Controllers
{
    public class AbsenceController : Controller
    {
        

        private IAbsenceService absenceService { get; set; }
        private UserManager<EdumanUser> userManager { get; set; }
        public AbsenceController(IAbsenceService absenceService, UserManager<EdumanUser> userManager)
        {
            this.absenceService = absenceService;
            this.userManager = userManager;
        }


        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(CreateAbsenceBindingModel createAbsenceBindingModel)
        {
            try
            {
                await absenceService.CreateAsync(createAbsenceBindingModel, this.User.Identity.Name);
            }
            catch (Exception e)
            {
                if (e.Message == "The User is either non-existent or is not a student") return this.View();
            }
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> All()
        {
            return this.View(await absenceService.GetAllAsync(this.userManager.GetUserId(this.User)));
        }

    }
}
