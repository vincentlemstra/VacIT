using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacIT.Data;

namespace VacIT.Controllers
{
    public class JobListingsController : Controller
    {
        private readonly VacITContext _context;

        public JobListingsController(VacITContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.JobListings.ToListAsync();
            return View(data);
        }
    }
}
