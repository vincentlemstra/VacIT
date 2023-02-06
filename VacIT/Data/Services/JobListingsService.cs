using VacIT.Data.Base;
using VacIT.Models;

namespace VacIT.Data.Services
{
    public class JobListingsService : EntityBaseRepository<JobListing>, IJobListingsService
    {
        public JobListingsService(VacITContext context) : base(context)
        {
        }
    }
}