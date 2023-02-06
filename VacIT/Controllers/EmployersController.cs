using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacIT.Data;

namespace VacIT.Controllers
{
    public class EmployersController : Controller
    {
        private readonly VacITContext _context;

        public EmployersController(VacITContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Employers.ToListAsync();
            return View(data);
        }
    }
}