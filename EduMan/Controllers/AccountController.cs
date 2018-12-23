using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models;
using Eduman.Models.BindingModels;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Eduman.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<EdumanUser> signInManager;
        private IAccountService accountService;

        public AccountController(SignInManager<EdumanUser> signInManager, IAccountService accountService)
        {
            this.signInManager = signInManager;
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginBindingModel loginBindingModel)
        {
            EdumanUser user = signInManager.UserManager.Users.FirstOrDefault(u => u.UserName == loginBindingModel.Username);
            SignInResult result = null;
            if(user.IsConfirmed)result = this.signInManager.PasswordSignInAsync(user, loginBindingModel.Password, isPersistent: false, lockoutOnFailure: false).Result;

            if (result.Succeeded && user.IsConfirmed)
            {
                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterBindingModel registerBindingModel)
        {
            var user = new EdumanUser()
            {
                Email = registerBindingModel.Email,
                UserName = registerBindingModel.Username,
                FirstName = registerBindingModel.FirstName,
                LastName = registerBindingModel.LastName,
                Number = registerBindingModel.Number,
                School = registerBindingModel.School
            };
            

            accountService.AddUserToPending(user, registerBindingModel.Role);
            return this.View("~/Views/Account/RegisterRequestNotification.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
