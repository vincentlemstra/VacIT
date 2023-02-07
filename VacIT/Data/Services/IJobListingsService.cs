using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public interface IJobListingsService : IEntityBaseRepository<JobListing>
    {
        Task<JobListing> GetJobListingByIdAsync(int id);
        Task<IEnumerable<JobListing>> GetAllJobListingsByEmployerIdAsync(int id);
    }
}