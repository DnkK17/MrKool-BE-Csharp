using MrKoolApplication.Models;

namespace MrKool.Models
{
    public class Wallet
    {
        public int WalletID { get; set; }
        public long Balance { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        public Guid? userID { get; set; }

        public Users? User {  get; set; } 
        // Relationships
        /*public int ManagerID {  get; set; }
        public Manager Manager { get; set; } = null!;

        public int TechnicianID {  get; set; }
        public Technician Technician { get; set; } = null!;*/

        public ICollection<Transaction>? TransactionList { get; set; }
    }
}
