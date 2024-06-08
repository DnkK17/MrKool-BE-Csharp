using MrKoolApplication.Models;

namespace MrKool.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        // Relationships
        public int userID   { get; set; }
        public User user { get; set; }
        public ICollection<Technician> TechnicianList { get; set; }
        public ICollection<Request> RequestList { get; set; }

        public ICollection<Station> StationList { get; set; }
        public Wallet Wallet { get; set; }
    }
}
