using System.ComponentModel.DataAnnotations;
using VacIT.Data.Base;

namespace VacIT.Models
{
    public class Profile : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string ProfilePicURL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Residence { get; set; }
        public string Motivation { get; set; }
        public string CVURL { get; set; }

        // Relationships
        public List<JobListing> JobListings { get; set; }
    }
}