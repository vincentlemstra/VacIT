using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacIT.Models
{
    public class JobListing
    {
        [Key]
        public int Id { get; set; }

        public int EmployerId { get; set; }
        [ForeignKey("EmployerId")]
        [Display(Name = "Bedrijfsnaam")]
        public Employer Employer { get; set; }

        [Display(Name = "Functieomschrijving")]
        public string Name { get; set; }
        [Display(Name = "Niveau")]
        public string Level { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }
        [Display(Name = "Plaats")]
        public string Residence { get; set; }
        [Display(Name = "Beschrijving")]
        public string Description { get; set; }
    }
}
