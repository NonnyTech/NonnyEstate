using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nonny_Estate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nonny_Estate.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(SignInManager<ApplicationUser> signInManager,
                        UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult LoginForm(bool succeeded)
        {
            if (succeeded)
            {
                ViewBag.Success = "Yes";
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginForm(Login login)
        {
            
            if (!ModelState.IsValid) return View(login);
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("Invalid", "Invalid Login attempts");
                return View(login);
            }
            var results = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            
            if (!results.Succeeded)
            {
                ModelState.AddModelError("Invalid", "Invalid login attempt");
                return View(login);
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction(nameof(LoginSuccess));
        }

        public IActionResult Register()

        {

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(Registration registration)
        {
            if (!ModelState.IsValid) return View(registration);

            var user = new ApplicationUser
            {

                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress,
                EmailConfirmed = true,
                NoOfCars = registration.NoOfCars
                


            };
            var result = await _userManager.CreateAsync(user, registration.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Invalid", result.Errors.FirstOrDefault().Description);
                return View(registration);
            }

            return RedirectToAction(nameof(LoginForm), new { succeeded = true });
        }

        //[Authorize]
        public IActionResult LoginSuccess()
        {
            return View();
        }


        public async Task<IActionResult>Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LoginForm");

        }
}
    }

