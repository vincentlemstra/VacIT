using System.ComponentModel.DataAnnotations;
using VacIT.Data.Base;

namespace VacIT.Models
{
    public enum Role
    {
        Regular = 1,
        Employer,
        Admin
    }

    public class LoginInfo : IEntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
