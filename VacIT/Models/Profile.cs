using System.ComponentModel.DataAnnotations;

namespace VacIT.Models
{
    public class Profile
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(75)]
        public string? Email { get; set; }
        //public string password { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [StringLength(6)]
        public string? Zipcode { get; set; }
        [StringLength(50)]
        public string? Residence { get; set; }
        public string? Motivation { get; set; }
        [StringLength(50)]
        public string? ProfilePic { get; set; }
        [StringLength(50)]
        public string? CV { get; set; }
        // public string? Role { get; set; }
        public ICollection<JobListing>? JobListings { get; set; }
    }
}
