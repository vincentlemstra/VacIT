using VacIT.Models;

namespace VacIT.Data.Services
{
    public interface IJobListingsService
    {
        Task AddJobListing(JobListing jobListing);

        Task<IEnumerable<JobListing>> GetAllJobListings();

        Task<JobListing> GetJobListingById(int id);

        Task<JobListing> UpdateJobListing(int id, JobListing jobListing);

        Task DeleteJobListing(int id);
    }
}