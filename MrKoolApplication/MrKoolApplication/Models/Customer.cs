using MrKoolApplication.Models;

namespace MrKool.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string? Telephone { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }

        public bool? Status { get; set; } = true;   
        public bool? IsDeleted { get; set; } =false;

        // Relationship
        public Guid? userID { get; set; }
        public Users? user { get; set; }

        public int? AreaID   { get; set; }
        public Area? Area { get; set; }

        public virtual ICollection<Order>? OrderList { get; set; }
        public virtual ICollection<FixHistory>? FixHistoryList { get; set; }
        public virtual ICollection<Request>? RequestList { get; set; }
    }
}
