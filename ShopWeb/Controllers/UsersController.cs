using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Migrations;
using ShopWeb.Models;

namespace ShopWeb.Controllers
{
    public class UsersController : Controller
    {
        UserManager<ApplicationUser> UserManager;
        SignInManager<ApplicationUser> signinManager;
        public UsersController(UserManager<ApplicationUser> manager,SignInManager<ApplicationUser> signManager)
        {
            UserManager = manager;
            signinManager = signManager;

        }
        public ActionResult signup()
        {

            return View(new Users());
        }
        [HttpPost]
        public async Task<ActionResult> Signup(Users user)
        {
            var NewUser = new ApplicationUser()
            {
                Email = user.Eamil,
                UserName = user.Eamil

            };
            var result = await UserManager.CreateAsync(NewUser, user.Password);
            if (result.Succeeded)
            {
                return Redirect("~/");
            }
            else
                ViewBag.ErrorMessage = result;
            return View("signup",user);
        }
        [HttpPost]
        public async Task<ActionResult> Login(Users user)
        {

            var result = await signinManager.PasswordSignInAsync(user.Eamil, user.Password, true, true);
            if (string.IsNullOrEmpty(user.ReturnUrl))
                user.ReturnUrl = "~/";


            if (result.Succeeded)
            {
                return Redirect(user.ReturnUrl);
            }
            else
                ViewBag.ErrorMessage = result;
            return View("login", user);
        }

        public async Task<ActionResult> LogOut()
        {
            await signinManager.SignOutAsync();
           return Redirect("~/");
        }
        public IActionResult login(string ReturnUrl)
        {

            return View(new Users()
            {
                ReturnUrl = ReturnUrl
            }) ;
        }
    }
}
