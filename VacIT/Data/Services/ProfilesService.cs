using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class ProfilesService : LoginInfoEntityBaseRepository<Profile>, IProfilesService
    {
        public ProfilesService(VacITContext context) : base(context)
        {
        }
    }
}