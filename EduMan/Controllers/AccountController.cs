using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduman.Models;
using Eduman.Models.BindingModels;
using Eduman.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
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
        public IActionResult Login(LoginBindingModel loginBindingModel)
        {
            EdumanUser user = signInManager.UserManager.Users.FirstOrDefault(u => u.UserName == loginBindingModel.Username);
            SignInResult result = null;
            if (user == null) return this.View();
            if (!user.IsConfirmed) return this.View();
            result = this.signInManager.PasswordSignInAsync(user, loginBindingModel.Password, isPersistent: false, lockoutOnFailure: false).Result;
            if (result.Succeeded && user.IsConfirmed)
            {
                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterBindingModel registerBindingModel)
        {
            var user = Mapper.Map<EdumanUser>(registerBindingModel);
            user.IsConfirmed = false;
            var result = this.signInManager.UserManager.CreateAsync(user, registerBindingModel.Password).Result;
            if (result.Succeeded)
            {
                return this.View("~/Views/Account/RegisterRequestNotification.cshtml");
            }

            return this.View();

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
