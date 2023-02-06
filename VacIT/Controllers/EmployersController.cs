using Microsoft.AspNetCore.Mvc;
using VacIT.Data.Services;

namespace VacIT.Controllers
{
    public class EmployersController : Controller
    {
        private readonly IEmployersService _service;

        public EmployersController(IEmployersService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
    }
}