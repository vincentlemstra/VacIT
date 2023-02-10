using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class EmployersService : LoginInfoEntityBaseRepository<Employer>, IEmployersService
    {
        public EmployersService(VacITContext context) : base(context)
        {
        }
    }
}