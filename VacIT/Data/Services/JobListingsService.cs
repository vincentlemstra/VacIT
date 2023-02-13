using Microsoft.EntityFrameworkCore;
using System;
using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class JobListingsService : EntityBaseRepository<JobListing>, IJobListingsService
    {
        public JobListingsService(VacITContext context) : base(context)
        {
        }

        public async Task<JobListing> GetJobListingByIdAsync(int id)
        {
            return await _context.JobListings
                .Include(e => e.Employer)
                .FirstAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<JobListing>> GetAllJobListingsByEmployerIdAsync(int id)
        {
            return await _context.JobListings.Where(n => n.EmployerId == id).ToListAsync();
        }

        public async Task AddNewJobListingAsync(Employer employer, JobListing data)
        {
            var newJobListing = new JobListing()
            {
                EmployerId = employer.Id,
                LogoURL = data.LogoURL,
                Name = data.Name,
                Level = data.Level,
                Date = DateTime.Today,
                Residence = employer.Residence,
                Description = data.Description,
            };

            await _context.JobListings.AddAsync(newJobListing);
            await _context.SaveChangesAsync();
        }

        public async Task<Employer> GetEmployerById(int id)
        {
            return await _context.Employers.FirstAsync(n => n.LoginInfoId == id);
        }
    }
}