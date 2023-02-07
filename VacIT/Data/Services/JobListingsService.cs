using Microsoft.EntityFrameworkCore;
using System;
using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class JobListingsService : EntityBaseRepository<JobListing>, IJobListingsService
    {
        private readonly VacITContext _context;
        public JobListingsService(VacITContext context) : base(context)
        {
            _context = context;
        }

        public async Task<JobListing> GetJobListingByIdAsync(int id)
        {
            return await _context.JobListings
                .Include(e => e.Employer)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<JobListing>> GetAllJobListingsByEmployerIdAsync(int id)
        {
            return await _context.JobListings.Where(n => n.EmployerId == id).ToListAsync();
        }
    }
}