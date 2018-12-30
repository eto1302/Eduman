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
    public class FeesController : Controller
    {
        private IFeeService feeService;
        private UserManager<EdumanUser> userManager { get; set; }
        public FeesController(UserManager<EdumanUser> userManager, IFeeService feeService)
        {
            this.userManager = userManager;
            this.feeService = feeService;
        }


        [HttpGet]
        [Authorize(Roles = "Teacher, Principal")]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        [Authorize(Roles = "Teacher, Principal")]
        public async Task<IActionResult> Create(CreateFeeBindingModel createFeeBindingModel)
        {
            try
            {
                await feeService.CreateAsync(createFeeBindingModel, this.User.Identity.Name);
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
            return this.View(await feeService.GetAllAsync(this.userManager.GetUserId(this.User)));
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            return this.View(await feeService.GetFeeDetails(id));
        }
    }
}
