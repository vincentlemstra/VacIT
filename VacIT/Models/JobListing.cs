using System.ComponentModel.DataAnnotations;

namespace VacIT.Models
{
    public class JobListing
    {
        public int Id { get; set; }
        public Employer Employer { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Level { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string? Residence { get; set; }
        public string? Motivation { get; set; }
    }
}
