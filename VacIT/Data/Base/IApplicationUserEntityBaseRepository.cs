using VacIT.Models;

namespace VacIT.Data.Base
{
    public interface IApplicationUserEntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IApplicationUserEntityBase, new()
    {
        Task<T> GetByUserAsync(ApplicationUser applicationUser);
    }
}
