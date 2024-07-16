using MrKoolApplication.Enum;

namespace MrKool.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string? Title { get; set; }
        public string? Detail { get; set; }
        public string Address { get; set; }

        public Status Status { get; set; }

        public double? TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        // Relationships
        public ICollection<OrderDetail>? OrderDetailList { get; set; }

        public int? TechnicianID { get; set; }

        public Technician? Technician { get; set; }
       

        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }

        /*public Request Request { get; set; }*/

        public Transaction? Transaction { get; set; }
    }
}
