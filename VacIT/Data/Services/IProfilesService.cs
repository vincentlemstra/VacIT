using VacIT.Data.Base;
using VacIT.Data.ViewModels;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public interface IProfilesService : IEntityBaseRepository<Profile>
    {
        Task<Profile> GetProfileByLoginInfoIdAsync(int id);
        Task<IEnumerable<Profile>> GetAllProfilesAsync();
        Task<Profile> GetProfileByEmailAsync(string email);
        Task CreateProfileWithLoginAsync(RegisterVM data);
        Task<Profile> GetProfileWithLoginAsync(int id);
        Task UpdateProfileWithLoginAsync(RegisterVM data);
    }
}