using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class ProfilesService : ApplicationUserEntityBaseRepository<Profile>, IProfilesService
    {
        public ProfilesService(VacITContext context) : base(context)
        {
        }
    }
}