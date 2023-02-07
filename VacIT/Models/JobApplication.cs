using System.ComponentModel.DataAnnotations.Schema;
using VacIT.Data.Base;

namespace VacIT.Models
{
    public class JobApplication : IEntityBase
    {
        public int Id { get; set; }

        public int? JobListingId { get; set; }
        public JobListing JobListing { get; set; }

        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }

        public bool Invite { get; set; }
        public DateTime InviteDate { get; set; }
    }
}
