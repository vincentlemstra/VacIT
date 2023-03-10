using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Dynamic;
using System.Security.Claims;
using VacIT.Data.Services;
using VacIT.Models;

namespace VacIT.Controllers
{
    public class JobListingsController : Controller
    {
        private readonly IJobListingsService _service;

        public JobListingsController(IJobListingsService service)
        {
            this._service = service;
        }

        // =================TESTS =====================
        public async Task<IActionResult> Test()
        {
            var data = await _service.GetAllJobListingsByEmployerIdAsync(1);
            return View(data);
        }
        // ============================================

        // GET: /
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: JobListings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobListings/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Employer,LogoURL,Name,Level,Date,Residence,Description")] JobListing jobListing)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employer employer = await _service.GetEmployerById(Int32.Parse(id));

            await _service.AddNewJobListingAsync(employer, jobListing);
            return RedirectToAction(nameof(Index));

        }

        // GET: JobListings/Details/1
        public async Task<IActionResult> Details(int id)
        {
            dynamic model = new ExpandoObject();
            model.jobListingDetails = await _service.GetJobListingByIdAsync(id);
            model.employerJobListings = await _service.GetAllJobListingsByEmployerIdAsync(model.jobListingDetails.EmployerId);

            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // GET: JobListings/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var jobListingDetails = await _service.GetByIdAsync(id);
            if (jobListingDetails == null)
            {
                return View("NotFound");
            }
            return View(jobListingDetails);
        }

        // POST: JobListings/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Employer,LogoURL, Name,Level,Date,Residence,Description")] JobListing jobListing)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, jobListing);
                return RedirectToAction(nameof(Index));
            }
            return View(jobListing);
        }

        // GET: JobListings/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var jobListingDetails = await _service.GetByIdAsync(id);
            if (jobListingDetails == null)
            {
                return View("NotFound");
            }
            return View(jobListingDetails);
        }

        // POST: JobListings/Edit
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobListingDetails = await _service.GetByIdAsync(id);
            if (jobListingDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}