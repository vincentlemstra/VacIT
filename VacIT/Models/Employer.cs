using System.ComponentModel.DataAnnotations;

namespace VacIT.Models
{
    public class Employer
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Website { get; set; }
        public string? Address { get; set; }
        [StringLength(6)]
        public string? Zipcode { get; set; }
        [StringLength(50)]
        public string? Residence { get; set; }
        public string? Description { get; set; }
        [StringLength(50)]
        public string? ProfilePic { get; set; }
        [StringLength(50)]
        //public string? Password { get; set; }
        // public string? Role { get; set; }
        public ICollection<JobListing>? JobListings { get; set; }
    }
}
