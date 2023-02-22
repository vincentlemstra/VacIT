using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Dynamic;
using System.Security.Claims;
using VacIT.Data.Services;
using VacIT.Data.ViewModels;
using VacIT.Models;

namespace VacIT.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IProfilesService _service;

        public ProfilesController(IProfilesService service)
        {
            this._service = service;
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllProfilesAsync();
            return View(data);
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var profileDetails = await _service.GetProfileByLoginInfoIdAsync(id);
            if (profileDetails == null)
            {
                return View("NotFound");
            }
            return View(profileDetails);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM data)
        {
            if (!ModelState.IsValid) return View(data);

            var user = await _service.GetProfileByEmailAsync(data.Email);
            if (user != null)
            {
                TempData["EmailError"] = "Dit email adres bestaat al";
                return View(data);
            }

            await _service.CreateProfileWithLoginAsync(data);
            TempData["RegisterSuccess"] = "Succesvolle register. Je kunt nu inloggen.";
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var profileDetails = await _service.GetProfileWithLoginAsync(id);
            if (profileDetails == null) return View("NotFound");

            var response = new RegisterVM()
            {
                Id = profileDetails.Id,
                ProfilePicURL = profileDetails.ProfilePicURL,
                FirstName = profileDetails.FirstName,
                LastName = profileDetails.LastName,
                Email = profileDetails.LoginInfo.Email,
                Password = profileDetails.LoginInfo.Password,
                BirthDate = profileDetails.BirthDate,
                Phone = profileDetails.Phone,
                Address = profileDetails.Address,
                Zipcode = profileDetails.Zipcode,
                Residence = profileDetails.Residence,
                Motivation = profileDetails.Motivation,
                CVURL = profileDetails.CVURL,
            };

            return View(response);
        }

        // POST: Profiles/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, RegisterVM data)
        {
            if (id != data.Id) return View(data);

            if (ModelState.IsValid)
            {
                await _service.UpdateProfileWithLoginAsync(data);
                TempData["Success"] = "Gegevens succesvol aangepast.";
                return View(data);
            }
            return View(data);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var profileDetails = await _service.GetByIdAsync(id);
            if (profileDetails == null)
            {
                return View("NotFound");
            }
            return View(profileDetails);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profileDetails = await _service.GetByIdAsync(id);
            if (profileDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}