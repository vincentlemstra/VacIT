using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            //var data = await _context.JobListings.Include(n => n.Employer).OrderByDescending(n => n.Date).ToListAsync();
            var data = await _service.GetAllJobListings();
            return View(data);
        }

        // GET: JobListings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobListings/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Employer,LogoURL, Name,Level,Date,Residence,Description")] JobListing jobListing)
        {
            if (ModelState.IsValid)
            {
                await _service.AddJobListing(jobListing);
                return RedirectToAction(nameof(Index));
            }
            return View(jobListing);
        }

        // GET: JobListings/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var jobListingDetails = await _service.GetJobListingById(id);
            if (jobListingDetails == null)
            {
                return View("NotFound");
            }
            return View(jobListingDetails);
        }

        // GET: JobListings/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var jobListingDetails = await _service.GetJobListingById(id);
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
                await _service.UpdateJobListing(id, jobListing);
                return RedirectToAction(nameof(Index));
            }
            return View(jobListing);
        }

        // GET: JobListings/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var jobListingDetails = await _service.GetJobListingById(id);
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
            var jobListingDetails = await _service.GetJobListingById(id);
            if (jobListingDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteJobListing(id);
            return RedirectToAction(nameof(Index));
        }
    }
}