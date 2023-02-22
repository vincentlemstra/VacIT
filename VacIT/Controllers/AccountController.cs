using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using VacIT.Data;
using VacIT.Data.Services;
using VacIT.Models;

namespace VacIT.Controllers
{
    public class AccountController : Controller
    {
        private readonly VacITContext _context;

        public AccountController(VacITContext context)
        {
            this._context = context;
        }

        // Get: Login
        public IActionResult Login()
        {
            return View();
        }

        // Post: Register
        [HttpPost]
        public async Task<IActionResult> Login(LoginInfo loginInfo)
        {
            if (ModelState.IsValid)
            {
                var user = _context.LoginInfo.FirstOrDefault(p => p.Password == loginInfo.Password && p.Email == loginInfo.Email);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, Convert.ToString(user.Role)),
                    };

                    // Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Set Authentication Properties
                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    // SignInAsync is a Extension method for Sign in a principal for the specified scheme.
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    TempData["LoginSuccess"] = "Succesvol login";
                    return LocalRedirect("/");

                }
                else
                {
                    TempData["LoginError"] = "Email en/of wachtwoord komt niet overeen";
                    return View(loginInfo);
                }
            }
            return View(loginInfo);
        }

        public async Task<IActionResult> Logout()
        {
            // SignOutAsync is Extension method for SignOut 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Redirect to home page    
            return LocalRedirect("/");
        }

        //// Get: Register
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //// todo-0 register -> check udemy course (working with movie data)
        //// Post: Register
        //[HttpPost]
        //public async Task<IActionResult> Register([Bind("Email","Password")]LoginInfo loginInfo)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
