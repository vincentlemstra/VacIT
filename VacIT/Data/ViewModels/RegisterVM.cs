using System.ComponentModel.DataAnnotations;

namespace VacIT.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Volledige Naam")]
        [Required(ErrorMessage = "Volledige naam is verplicht")]
        public string FullName { get; set; }

        [Display(Name = "Email Adres")]
        [Required(ErrorMessage = "Email Adres is verplicht")]
        public string Email { get; set; }

        [Display(Name = "Wachtwoord")]
        [Required(ErrorMessage = "Wachtoord is verplicht")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Herhaal wachtwoord")]
        [Required(ErrorMessage = "Herhaal wachtoord is verplicht")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen")]
        public string ConfirmPassword { get; set; }
    }
}
