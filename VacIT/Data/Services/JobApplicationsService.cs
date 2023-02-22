using Microsoft.EntityFrameworkCore;
using VacIT.Data.Base;
using VacIT.Data.ViewModels;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class JobApplicationsService : EntityBaseRepository<JobApplication>, IJobApplicationsService
    {
        public JobApplicationsService(VacITContext context) : base(context)
        {
        }

        public async Task AddNewJobApplicationAsync(NewJobApplicationVM data)
        {
            var newJobApplication = new JobApplication()
            {
                JobListingId = data.JobListingId,
                ProfileId = data.ProfileId,
                ApplyDate = data.ApplyDate,
                Invite = data.Invite,
                InviteDate = data.InviteDate,
            };
            await _context.JobApplications.AddAsync(newJobApplication);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplicationsByLoginInfoIdAsync(int loginInfoId)
        {
            var user = await _context.Profiles
                .Include(l => l.LoginInfo)
                .FirstOrDefaultAsync(p => p.LoginInfoId == loginInfoId);

            var result = await _context.JobApplications
                .Include(jl => jl.JobListing)
                .Include(e => e.JobListing.Employer)
                .Where(n => n.ProfileId == user.Id)
                .ToListAsync();

            return result;
        }

        public async Task<Profile> GetProfileIdByLoginInfoIdAsync(int loginInfoId)
        {
            return await _context.Profiles
                .Include(l => l.LoginInfo)
                .FirstAsync(p => p.LoginInfoId == loginInfoId);
        }
    }
}
