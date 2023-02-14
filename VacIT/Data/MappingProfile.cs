using VacIT.Data.DTO;
using VacIT.Models;

namespace VacIT.Data
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<JobListing, JobListingDTO>();
            CreateMap<JobListingForCreationDTO, JobListing>();
            CreateMap<JobListingForUpdateDTO, JobListing>();

            CreateMap<Employer, EmployerDTO>();
        }
    }
}
