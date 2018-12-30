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
using Eduman.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
                if (e.Message == "The User is non-existent") return this.RedirectToAction("ConfirmUser");
            }
            return this.RedirectToAction("ConfirmUser");
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
        public async Task<IActionResult> Register(RegisterBindingModel registerBindingModel)
        {
            var user = new EdumanUser
            {
                FirstName = registerBindingModel.FirstName,
                LastName = registerBindingModel.LastName,
                Email = registerBindingModel.Email,
                UserName = registerBindingModel.Username,
                School = registerBindingModel.School,
                Number = registerBindingModel.Number,
                IsConfirmed = false
            };
            var result = this.signInManager.UserManager.CreateAsync(user, registerBindingModel.Password).Result;
            if (result.Succeeded)
            {
                await signInManager.UserManager.AddToRoleAsync(user, registerBindingModel.Role);
                await signInManager.SignInAsync(user, isPersistent: false);
                await signInManager.SignOutAsync();
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
