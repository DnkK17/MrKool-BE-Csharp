namespace MrKool.Models
{
    public class OrderDetail
    {
        public string Image { get; set; }

        public bool Status { get; set; }

        // Relationships
        public int OrderID { get; set; }

        public Order Order { get; set; }

        public int TechnicianID;

        public Technician Technician { get; set; }

        public int ServiceID { get; set; }

        public Service Service { get; set; }
    }
}
