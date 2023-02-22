using VacIT.Data.Base;
using VacIT.Data.ViewModels;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public interface IJobApplicationsService : IEntityBaseRepository<JobApplication>
    {
        Task<IEnumerable<JobApplication>> GetJobApplicationsByLoginInfoIdAsync(int id);
        Task AddNewJobApplicationAsync(NewJobApplicationVM data);
        Task<Profile> GetProfileIdByLoginInfoIdAsync(int loginInfoId);
    }
}
