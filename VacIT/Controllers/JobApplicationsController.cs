using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VacIT.Data.Services;
using VacIT.Data.ViewModels;
using VacIT.Models;

namespace VacIT.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly IJobApplicationsService _service;

        public JobApplicationsController(IJobApplicationsService service)
        {
            this._service = service;
        }

        // GET: JobApplications/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var jobApplicationsDetails = await _service.GetJobApplicationsByLoginInfoIdAsync(id);
            if (!jobApplicationsDetails.Any())
            {
                ViewBag.NoApplications = "Je hebt nog geen sollicitaties.";
            }
            return View(jobApplicationsDetails);
        }

        // POST: Profiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewJobApplicationVM jobApplication)
        {
            // get current joblisting id
            string joblistingUrl = Request.Headers["Referer"].ToString();
            int joblistingId = int.Parse(joblistingUrl.Substring(joblistingUrl.Length - 1));

            // get current profile id
            string loginInfoId = @User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _service.GetProfileIdByLoginInfoIdAsync(int.Parse(loginInfoId));

            // set jobapplication
            jobApplication.JobListingId = joblistingId;
            jobApplication.ProfileId = user.Id;
            jobApplication.ApplyDate = DateTime.Today;
            jobApplication.Invite = false;
            jobApplication.InviteDate = null;

            if (ModelState.IsValid)
            {
                await _service.AddNewJobApplicationAsync(jobApplication);
                //return RedirectToAction(nameof(Index));
                TempData["JobApplicationSuccess"] = "Je hebt gesolliciteerd! Het bedrijf zal contact met je opnemen.";
                return LocalRedirect("/");
            }
            return View(jobApplication);
        }
    }
}
