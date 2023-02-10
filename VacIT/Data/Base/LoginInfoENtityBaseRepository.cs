using Microsoft.EntityFrameworkCore;
using VacIT.Models;

namespace VacIT.Data.Base
{
    public class LoginInfoEntityBaseRepository<T> : EntityBaseRepository<T>, ILoginInfoEntityBaseRepository<T> where T : class, ILoginInfoEntityBase, new()
    {
        public LoginInfoEntityBaseRepository(VacITContext context) : base(context)
        {
        }

        public async Task<T> GetByUserAsync(LoginInfo loginInfo) => await _context.Set<T>().FirstAsync(n => n.LoginInfo.Id == loginInfo.Id);
    }
}