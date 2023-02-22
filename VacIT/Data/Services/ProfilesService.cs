using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Policy;
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

        public async Task<Profile> GetProfileWithLoginAsync(int id)
        {
            return await _context.Profiles
                .Include(l => l.LoginInfo)
                .FirstAsync(n => n.Id == id);
        }

        public async Task UpdateProfileWithLoginAsync(RegisterVM data)
        {
            var dbLoginInfo = await _context.Profiles
                .Include(l => l.LoginInfo)
                .FirstOrDefaultAsync(n => n.Id == data.Id);
                
            if (dbLoginInfo != null)
            {
                dbLoginInfo.LoginInfo.Email = data.Email;
                dbLoginInfo.LoginInfo.Password = data.Password;
            }
            await _context.SaveChangesAsync();

            var dbProfile = await _context.Profiles.FirstOrDefaultAsync(n => n.Id == data.Id);       
            if (dbProfile != null)
            {
                dbProfile.ProfilePicURL = data.ProfilePicURL;
                dbProfile.FirstName = data.FirstName;
                dbProfile.LastName = data.LastName;
                dbProfile.BirthDate = data.BirthDate;
                dbProfile.Phone = data.Phone;
                dbProfile.Address = data.Address;
                dbProfile.Zipcode = data.Zipcode;
                dbProfile.Residence = data.Residence;
                dbProfile.Motivation = data.Motivation;
                dbProfile.CVURL = data.CVURL;
            }
            await _context.SaveChangesAsync();
        }
    }
}