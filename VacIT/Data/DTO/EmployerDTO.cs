namespace VacIT.Data.DTO
{
    public class EmployerDTO
    {
        public int Id { get; set; }
        public string LogoURL { get; set; }
        public string Name { get; set; }
        public string WebsiteURL { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Residence { get; set; }
        public string Description { get; set; }
        public IEnumerable<JobListingDTO> JobListings { get; set; }
    }
}