namespace MrKool.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        // Relationships
        public Area Area { get; set; }

        public Customer Customer { get; set; }

        public Station Station { get; set; }

        public Manager Manager { get; set; }

        public Order Order { get; set; } = null!;

        public Technician Technician { get; set; }
    }
}
