using Microsoft.EntityFrameworkCore;
using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class ProfilesService : LoginInfoEntityBaseRepository<Profile>, IProfilesService
    {
        public ProfilesService(VacITContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
        {
            return await _context.Profiles
                .Include(l => l.LoginInfo)
                .ToListAsync();
        }

        public async Task<Profile> GetProfileByLoginInfoIdAsync(int loginInfoId)
        {
            return await _context.Profiles
                .Include(l => l.LoginInfo)
                .FirstOrDefaultAsync(p => p.LoginInfoId == loginInfoId);
        }

    }
}