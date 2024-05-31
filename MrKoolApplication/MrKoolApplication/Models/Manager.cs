namespace MrKool.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        // Relationships
        public ICollection<Technician> TechnicianList { get; set; }
        public ICollection<Request> RequestList { get; set; }
        public Wallet Wallet { get; set; }
    }
}
