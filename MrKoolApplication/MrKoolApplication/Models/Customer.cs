namespace MrKool.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }

        // Relationship
        public Area Area { get; set; }

        public ICollection<Order> OrderList { get; set; }
        public ICollection<FixHistory> FixHistoryList { get; set; }
        public ICollection<Request> RequestList { get; set; }
    }
}
