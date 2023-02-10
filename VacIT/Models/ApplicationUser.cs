using VacIT.Data.Base;

namespace VacIT.Models
{
    public enum Role
    {
        User = 1,
        Employee,
        Admin
    }

    public class ApplicationUser : IEntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
