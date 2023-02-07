using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VacIT.Data.Base;

namespace VacIT.Models
{
    public class JobListing : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Werkgever mag niet leeg zijn")]
        public int EmployerId { get; set; }

        [ForeignKey("EmployerId")]
        [Display(Name = "Bedrijfsnaam")]
        public Employer Employer { get; set; }

        [Display(Name = "Logo URL")]
        public string LogoURL { get; set; }

        [Required(ErrorMessage = "Functieomschrijving mag niet leeg zijn")]
        [Display(Name = "Functieomschrijving")]
        [StringLength(50, ErrorMessage = "Funciteomschrijving mag niet groter zijn dan 50 karakters")]
        public string Name { get; set; }

        [Display(Name = "Niveau")]
        public string Level { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }

        [Display(Name = "Plaats")]
        public string Residence { get; set; }

        [Display(Name = "Beschrijving")]
        public string Description { get; set; }
    }
}