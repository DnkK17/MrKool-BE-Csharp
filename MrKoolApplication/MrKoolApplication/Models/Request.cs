namespace MrKool.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string RequestAddress { get; set; }
        public bool Status { get; set; }

        // Relationships
        public int AreaID   { get; set; }
        public Area Area { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int StationID { get; set; }
        public Station Station { get; set; }

        public int ManagerID { get; set; }
        public Manager Manager { get; set; }
        public List<Service> Services { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; } = null!;
        public int TechnicianID { get; set; }
        public Technician Technician { get; set; }
    }
}
