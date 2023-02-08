using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VacIT.Data;
using VacIT.Data.Static;
using VacIT.Data.ViewModels;
using VacIT.Models;

namespace VacIT.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly VacITContext _context;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            VacITContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (passwordCheck)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "JobListings");
                        }
                    }
                    TempData["Error"] = "Email en/of wachtwoord komt niet overeen.";
                    return View(loginVM);
                }
                TempData["Error"] = "Email en/of wachtwoord komt niet overeen.";
                return View(loginVM);
            }
            return View(loginVM);
        }

        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(registerVM.Email);
                if (user != null)
                {
                    TempData["Error"] = "Dit email adres bestaat al";
                    return View(registerVM);
                }
                var newUser = new ApplicationUser()
                {
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Email = registerVM.Email,
                    UserName = registerVM.Email
                };
                var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

                if (newUserResponse.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "user");
                    return View("RegisterSuccess");
                }
                return View(registerVM);

            }
            return View(registerVM);
        }
    }
}
