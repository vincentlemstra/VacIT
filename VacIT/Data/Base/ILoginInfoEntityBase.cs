using VacIT.Models;

namespace VacIT.Data.Base
{
    public interface ILoginInfoEntityBase : IEntityBase
    {
        LoginInfo LoginInfo { get; set; }
    }
}