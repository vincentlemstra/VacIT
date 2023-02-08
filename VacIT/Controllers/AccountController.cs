using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VacIT.Data;
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
    }
}
