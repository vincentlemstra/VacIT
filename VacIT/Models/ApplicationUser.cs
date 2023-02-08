using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VacIT.Models
{
    public class ApplicationUser : IdentityUser
    {
       [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Display(Name = "Achternaam")]
        public string LastName { get; set; }
    }
}
