using AutoMapper;
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

        public JobListingsController(VacITContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/LobListings
        [HttpGet]
        public ActionResult<IEnumerable<JobListing>> GetAllJobListings()
        {
            //var jobListings = _context.JobListings.Include(n => n.Employer).ToList();
            var jobListings = _context.JobListings.Include(n => n.Employer).ToList();
            var result = _mapper.Map<IEnumerable<JobListingDTO>>(jobListings);
            return Ok(result);
        }

        // GET api/LobListings/5
        [HttpGet("{id}", Name = "JobListingById")]
        public ActionResult<JobListing> GetJobListingById(int id)
        {
            var jobListing = _context.JobListings.FirstOrDefault(n => n.Id == id);
            if (jobListing == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<JobListingDTO>(jobListing);
            return Ok(result); // -> HTTP RESULT CODE 200
        }

        // POST api/LobListings
        [HttpPost]
        public ActionResult CreateJobListing([FromBody] JobListing newJobListing)
        {
            if (_context.JobListings == null)
            {
                return NotFound("Database not connected");
            }
            _context.JobListings.Add(newJobListing);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetJobListingById), new { id = newJobListing.Id }, null); // HTTP RESULT CODE 201
            // return CreatedAtAction(nameof(GetJobListing), new { id = newJobListing.Id }, newJobListing); // HTTP RESULT CODE 201
        }

        // PUT api/LobListings/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] JobListing updatedJobListing)
        {
            if (_context.JobListings == null)
            {
                return NotFound("Database not connected");
            }
            if (id != updatedJobListing.Id)
            {
                ModelState.AddModelError("Id", "Does not match Id in URL");
                return BadRequest(ModelState);
            }
            _context.JobListings.Update(updatedJobListing);
            _context.SaveChanges();
            return NoContent(); // HTTP RESULT CODE 204
        }

        // DELETE api/LobListings/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_context.JobListings == null)
            {
                return NotFound("Database not connected");
            }
            var jobListing = _context.JobListings.Find(id);
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