using Microsoft.EntityFrameworkCore;
using VacIT.Models;

namespace VacIT.Data
{
    public class VacITContext : DbContext
    {
        public VacITContext(DbContextOptions<VacITContext> options)
            : base(options)
        {
        }

        public DbSet<LoginInfo> LoginInfo { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
    }
}