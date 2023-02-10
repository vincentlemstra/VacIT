using VacIT.Models;

namespace VacIT.Data.Base
{
    public interface ILoginInfoEntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, ILoginInfoEntityBase, new()
    {
        Task<T> GetByUserAsync(LoginInfo loginInfo);
    }
}