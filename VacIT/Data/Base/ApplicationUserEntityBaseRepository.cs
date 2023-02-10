using Microsoft.EntityFrameworkCore;
using VacIT.Models;

namespace VacIT.Data.Base
{
    public class ApplicationUserEntityBaseRepository<T> : EntityBaseRepository<T>, IApplicationUserEntityBaseRepository<T> where T : class, IApplicationUserEntityBase, new()
    {
        public ApplicationUserEntityBaseRepository(VacITContext context) : base(context)
        {
        }

        public async Task<T> GetByUserAsync(ApplicationUser applicationUser)
        {
            return await _context.Set<T>().FirstAsync(n => n.ApplicationUser.Id == applicationUser.Id);
        }
    }
}
