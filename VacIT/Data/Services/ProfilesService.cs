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

        public async Task<Profile> GetProfileByEmailAsync(string email)
        {
            return await _context.Profiles
                .Include(l => l.LoginInfo)
                .FirstOrDefaultAsync(e => e.LoginInfo.Email == email);
        }

        public async Task<Profile> GetProfileByLoginInfoIdAsync(int loginInfoId)
        {
            return await _context.Profiles
                .Include(l => l.LoginInfo)
                .FirstAsync(p => p.LoginInfoId == loginInfoId);
        }
    }
}