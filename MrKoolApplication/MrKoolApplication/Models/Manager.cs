using MrKoolApplication.Models;

namespace MrKool.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public string Telephone { get; set; }
        public string Status { get; set; }

        // Relationships
        public User user { get; set; }
        public ICollection<Technician> TechnicianList { get; set; }
        public ICollection<Request> RequestList { get; set; }

        public ICollection<Station> StationList { get; set; }
        public Wallet Wallet { get; set; }
    }
}
