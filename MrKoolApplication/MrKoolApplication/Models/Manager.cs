using MrKoolApplication.Models;

namespace MrKool.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }
        public bool Status { get; set; }
        public string ManagerName  { get; set; }
        public bool IsDeleted { get; set; }

        // Relationships
        public Guid userID   { get; set; }
        public Users user { get; set; }
        public ICollection<Technician>? TechnicianList { get; set; }
        public ICollection<Request>? RequestList { get; set; }

        public ICollection<Station>? StationList { get; set; }
        public int? WalletID { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
