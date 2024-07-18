using MrKoolApplication.Models;

namespace MrKool.Models
{
    public class FixHistory
    {
        public int FixHistoryID { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        public bool? Status { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;

        // Relationships
        public int? TechnicianID {  get; set; }
        public Technician? Technician { get; set; }

        public int? CustomerID { get; set; }

        public Customer? Customer { get; set; }


        public ICollection<OrderDetail>? OrderDetailList { get; set; }
    }
}
