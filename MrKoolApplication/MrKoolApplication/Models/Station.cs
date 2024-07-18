namespace MrKool.Models
{
    public class Station
    {
        public int StationID { get; set; }
        public string Address { get; set; }

        public bool Status  { get; set; }

        public bool IsDeleted { get; set; }

        // Relationships
        public ICollection<Request>? RequestList { get; set; }

        public int? AreaID { get; set; }
        public Area? Area { get; set; }

        public int? ManagerID { get; set; }
        public Manager? Manager { get; set; }
        public ICollection<Technician>? TechnicianList { get; set; }
    }
}
