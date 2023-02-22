using VacIT.Models;

namespace VacIT.Data.ViewModels
{
    public class NewJobApplicationVM
    {
        public int JobListingId { get; set; }
        public int ProfileId { get; set; }
        public bool Invite { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime? InviteDate { get; set; }
    }
}
