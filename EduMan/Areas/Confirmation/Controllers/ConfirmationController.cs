using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eduman.Areas.Confirmation.Controllers
{

    [Area("Confirmation")]
    public class ConfirmationController : Controller
    {
        private IAccountService accountService { get; set; }

        public ConfirmationController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        [Authorize(Roles = "Principal")]
        public async Task<IActionResult> ConfirmUser()
        {
            return this.View(await accountService.GetAllUnconfirmedUsersAsync(this.User.Identity.Name));
        }

        [HttpPost]
        [Authorize(Roles = "Principal")]
        public IActionResult ConfirmUser(string id)
        {
            try
            {
                accountService.ConfirmUser(id);
            }
            catch (Exception e)
            {
                if (e.Message == "The User is non-existent") return this.View("~/Views/Shared/NonExistentStudentPage.cshtml");
            }
            return this.RedirectToAction("ConfirmUser");
        }
    }
}
