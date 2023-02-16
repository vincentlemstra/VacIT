using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacIT.Data;
using VacIT.Data.DTO;
using VacIT.Models;

// todo-1 change to async

namespace VacIT.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobListingsController : ControllerBase
    {
        private readonly VacITContext _context;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public JobListingsController(VacITContext context, IMapper mapper, ILoggerManager logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/LobListings
        [HttpGet]
        public ActionResult<IEnumerable<JobListing>> GetAllJobListings()
        {
            //var jobListings = _context.JobListings.Include(n => n.Employer).ToList();
            var jobListings = _context.JobListings.ToList();
            var result = _mapper.Map<IEnumerable<JobListingDTO>>(jobListings);
            return Ok(result);
        }

        // GET api/LobListings/5
        [HttpGet("{id}", Name = "JobListingById")]
        public ActionResult<JobListing> GetJobListingById(int id)
        {
            //var jobListing = _context.JobListings.FirstOrDefault(n => n.Id == id);
            var jobListing = _context.JobListings.Include(n => n.Employer).FirstOrDefault(n => n.Id == id);

            if (jobListing == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<JobListingDTO>(jobListing);
            return Ok(result); // -> HTTP RESULT CODE 200
        }

        // POST api/LobListings
        [HttpPost]
        public ActionResult CreateJobListing([FromBody] JobListingForCreationDTO jobListing)
        {
            var jobListingEntity = _mapper.Map<JobListing>(jobListing);

            _context.JobListings.Add(jobListingEntity);
            _context.SaveChanges();

            var newJobListing = _mapper.Map<JobListingDTO>(jobListingEntity);
            return CreatedAtAction(nameof(GetJobListingById), new { id = newJobListing.Id }, newJobListing); // HTTP RESULT CODE 201
        }

        // PUT api/LobListings/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] JobListingForUpdateDTO jobListing)
        {
            var jobListingEntity = _context.JobListings.FirstOrDefault(n => n.Id == id);
            if (jobListingEntity == null)
            {
                ModelState.AddModelError("Id", "Does not match Id in URL");
                return BadRequest(ModelState);
            }

            _mapper.Map(jobListing, jobListingEntity);
            _context.JobListings.Update(jobListingEntity);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/LobListings/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var jobListing = _context.JobListings.FirstOrDefault(n => n.Id == id);
            if (jobListing == null)
            {
                return NotFound();
            }
            _context.JobListings.Remove(jobListing);
            _context.SaveChanges();
            return Ok();
        }
    }
}