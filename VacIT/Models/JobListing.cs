using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VacIT.Data.Base;

namespace VacIT.Models
{
    public class JobListing : IEntityBase
    {
        // todo restricties toevoegen
        // todo error messages toevoegen

        public int Id { get; set; }

        public int EmployerId { get; set; }

        [Display(Name = "Bedrijfsnaam")]
        public Employer Employer { get; set; }

        [Display(Name = "Logo URL")]
        public string LogoURL { get; set; }

        [Display(Name = "Functieomschrijving")]
        [StringLength(50, ErrorMessage = "Funciteomschrijving mag niet groter zijn dan 50 karakters")]
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

        // Relationships
        public List<JobApplication> JobApplications { get; set; }
    }
}