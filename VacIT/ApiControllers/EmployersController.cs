using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacIT.Data.DTO;
using VacIT.Data;
using VacIT.Models;
using Microsoft.EntityFrameworkCore;

namespace VacIT.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        private readonly VacITContext _context;
        private readonly IMapper _mapper;

        public EmployersController(VacITContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employers
        [HttpGet]
        public ActionResult<IEnumerable<Employer>> GetAllEmployers()
        {
            var employers = _context.Employers
                .Include(jl => jl.JobListings)
                .ToList();
            var result = _mapper.Map<IEnumerable<EmployerDTO>>(employers);
            return Ok(result);
        }

        //GET api/Employers/5
        [HttpGet("{id}")]
        public ActionResult<Employer> GetEmployerById(int id)
        {
            var employer = _context.Employers
                .Include(jl => jl.JobListings)
                .FirstOrDefault(n => n.Id == id);
            if (employer == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<EmployerDTO>(employer);
            return Ok(result);
        }
    }
}
