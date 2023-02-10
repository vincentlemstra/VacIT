using VacIT.Models;

namespace VacIT.Data.Base
{
    public interface IApplicationUserEntityBase : IEntityBase
    {
        ApplicationUser ApplicationUser { get; set; }
    }
}