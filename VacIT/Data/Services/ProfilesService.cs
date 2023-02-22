using Microsoft.EntityFrameworkCore;
using VacIT.Data.Base;
using VacIT.Data.ViewModels;
using VacIT.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VacIT.Data.Services
{
    public class ProfilesService : LoginInfoEntityBaseRepository<Profile>, IProfilesService
    {
        public ProfilesService(VacITContext context) : base(context)
        {
        }

        public async Task CreateProfileWithLoginAsync(RegisterVM data)
        {
            var newLoginInfo = new LoginInfo()
            {
                Email = data.Email,
                Password = data.Password,
                Role = Role.User,
            };
            await _context.LoginInfo.AddAsync(newLoginInfo);
            await _context.SaveChangesAsync();

            var newProfile = new Profile()
            {
                LoginInfoId = newLoginInfo.Id,
                ProfilePicURL = data.ProfilePicURL,
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
                Phone = data.Phone,
                Address = data.Address,
                Zipcode = data.Zipcode,
                Residence = data.Residence,
                Motivation = data.Motivation,
                CVURL = data.CVURL,
            };
            await _context.Profiles.AddAsync(newProfile);
            await _context.SaveChangesAsync();
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