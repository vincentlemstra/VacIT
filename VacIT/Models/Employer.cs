using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VacIT.Data.Base;

namespace VacIT.Models
{
    public class Employer : ILoginInfoEntityBase
    {
        public int Id { get; set; }

        [Display(Name = "Logo URL")]
        public string LogoURL { get; set; }

        [Display(Name = "Bedrijfsnaam")]
        public string Name { get; set; }

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
        public ICollection<JobListing> JobListings { get; set; }

        // Login
        public int LoginInfoId { get; set; }
        public LoginInfo LoginInfo { get; set; }
    }
}