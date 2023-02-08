using System.ComponentModel.DataAnnotations;

namespace VacIT.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Adres")]
        [Required(ErrorMessage = "Email Adres is required")]
        public string Email { get; set; }

        [Display(Name = "Wachtwoord")]
        [Required(ErrorMessage = "Wachtoord is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
