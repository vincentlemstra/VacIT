using System.ComponentModel.DataAnnotations;

namespace VacIT.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Adres")]
        [Required(ErrorMessage = "Email Adres is verplicht")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Wachtwoord")]
        [Required(ErrorMessage = "Wachtoord is verplicht")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
