using VacIT.Models;

namespace VacIT.Data.DTO
{
    public class JobListingDTO
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        //public Employer Employer { get; set; }
        public string LogoURL { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public DateTime Date { get; set; }
        public string Residence { get; set; }
        public string Description { get; set; }
    }
}
