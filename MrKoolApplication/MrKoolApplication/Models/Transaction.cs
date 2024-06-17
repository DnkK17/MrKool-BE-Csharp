namespace MrKool.Models
{
    public class Transaction
    {
        public long TransactionID { get; set; }
        public long Amount { get; set; }
        public DateTime Date { get; set; }

        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        // Relationships
        public int WalletID { get; set; }
        public Wallet? Wallet { get; set; }

    }
}
