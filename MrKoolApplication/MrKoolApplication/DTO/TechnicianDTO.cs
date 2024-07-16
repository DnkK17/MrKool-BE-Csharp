using MrKool.Models;

namespace MrKoolApplication.DTO
{
    public class TechnicianDTO
    {
        public int TechnicianID { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string TechnicianName { get; set; }

        public int ManagerID { get; set; }

        public int StationID { get; set; }

        public int WalletID { get; set; }

    }
}
