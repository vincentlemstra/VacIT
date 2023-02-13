using Microsoft.AspNetCore.Mvc;
using VacIT.Data;
using VacIT.Models;

// todo-1 change to async

namespace VacIT.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobListingsController : ControllerBase
    {
        private readonly VacITContext _context;

        public JobListingsController(VacITContext context)
        {
            this._context = context;
        }

        // GET: api/LobListings
        [HttpGet]
        public ActionResult<IEnumerable<JobListing>> GetAllJobListings()
        {
            if (_context.JobListings == null)
            {
                return NotFound("Database not connected");
            }
            return _context.JobListings.ToList();
        }

        // GET api/LobListings/5
        [HttpGet("{id}")]
        public ActionResult<JobListing> GetJobListing(int id)
        {
            if (_context.JobListings == null)
            {
                return NotFound("Database not connected");
            }
            var jobListing = _context.JobListings.Find(id);
            if (jobListing == null || jobListing == null)
            {
                return NotFound();
            }
            return jobListing; // is: return Ok(jobListing) -> HTTP RESULT CODE 200
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
            return CreatedAtAction(nameof(GetJobListing), new { id = newJobListing.Id }, null); // HTTP RESULT CODE 201
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