using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Data;
using Eduman.Models;
using Eduman.Models.BindingModels;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eduman.Controllers
{
    public class EventController : Controller
    {


        private IEventService eventService { get; set; }
        private UserManager<EdumanUser> userManager { get; set; }
        public EventController(IEventService eventService, UserManager<EdumanUser> userManager)
        {
            this.eventService = eventService;
            this.userManager = userManager;
        }


        [HttpGet]
        [Authorize(Roles = "Teacher, Principal")]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        [Authorize(Roles = "Teacher, Principal")]
        public async Task<IActionResult> Create(CreateEventBindingModel createEventBindingModel)
        {
            try
            {
                await eventService.CreateAsync(createEventBindingModel, this.User.Identity.Name);
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
            return this.View(await eventService.GetAllAsync(this.userManager.GetUserId(this.User)));
        }

        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            return this.View(await eventService.GetEventDetails(id));
        }

    }
}
