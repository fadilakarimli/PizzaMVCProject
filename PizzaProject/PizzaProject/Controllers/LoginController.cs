using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.Models;
using PizzaProject.ViewModels.UI.Login;

namespace PizzaProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // İstifadəçini username və ya email ilə tap
            AppUser user = await _userManager.FindByNameAsync(model.UsernameOrEmail)
                            ?? await _userManager.FindByEmailAsync(model.UsernameOrEmail);

            if (user == null)
            {
                ModelState.AddModelError("", "Username və ya Email düzgün deyil!");
                return View(model);
            }

            // Password yoxla və login et
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // uğurlu login → Home
            }

            ModelState.AddModelError("", "Şifrə düzgün deyil!");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
