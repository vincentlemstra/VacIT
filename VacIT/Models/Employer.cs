using System.ComponentModel.DataAnnotations;

namespace VacIT.Models
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo URL")]
        public string LogoURL { get; set; }

        [Display(Name = "Bedrijfsnaam")]
        public string Name { get; set; }

        public string Password { get; set; }

        [Display(Name = "Website")]
        public string WebsiteURL { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Postcode")]
        public string Zipcode { get; set; }

        [Display(Name = "Plaatsnaam")]
        public string Residence { get; set; }

        [Display(Name = "Beschrijving")]
        public string Description { get; set; }

        // Relationships
        public List<JobListing> JobListings { get; set; }
    }
}