namespace VacIT.Data.DTO
{
    // todo add validation rules
    public class JobListingForUpdateDTO
    {
        public int EmployerId { get; set; }
        public string LogoURL { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public DateTime Date { get; set; }
        public string Residence { get; set; }
        public string Description { get; set; }
    }
}
