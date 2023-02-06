using Microsoft.EntityFrameworkCore;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class JobListingsService : IJobListingsService
    {
        private readonly VacITContext _context;

        public JobListingsService(VacITContext context)
        {
            _context = context;
        }

        public async Task AddJobListing(JobListing jobListing)
        {
            _context.JobListings.Add(jobListing);
            _context.SaveChanges();
        }

        public async Task DeleteJobListing(int id)
        {
            var result = await _context.JobListings.FirstOrDefaultAsync(n => n.Id == id);
            _context.JobListings.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobListing>> GetAllJobListings()
        {
            return await _context.JobListings.ToListAsync();
        }

        public async Task<JobListing> GetJobListingById(int id)
        {
            return await _context.JobListings.Include(m => m.Employer).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<JobListing> UpdateJobListing(int id, JobListing jobListing)
        {
            _context.Update(jobListing);
            await _context.SaveChangesAsync();
            return jobListing;
        }
    }
}