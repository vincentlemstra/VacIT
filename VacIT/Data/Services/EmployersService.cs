using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class EmployersService : ApplicationUserEntityBaseRepository<Employer>, IEmployersService
    {
        public EmployersService(VacITContext context) : base(context)
        {
        }
    }
}