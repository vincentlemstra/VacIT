using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VacIT.Data.Base;

namespace VacIT.Models
{
    public class LoginInfo : IEntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
