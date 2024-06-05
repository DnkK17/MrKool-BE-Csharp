namespace MrKool.Models
{
    public class Transaction
    {
        public long TransactionID { get; set; }
        public long Amount { get; set; }
        public DateTime Date { get; set; }

        // Relationships
        public Wallet Wallet { get; set; }

    }
}
