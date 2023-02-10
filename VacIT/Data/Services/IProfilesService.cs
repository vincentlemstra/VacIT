using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public interface IProfilesService : IEntityBaseRepository<Profile>
    {

        Task<Profile> GetProfileByIdAsync(int id);
        Task<IEnumerable<Profile>> GetAllProfilesAsync();

    }
}