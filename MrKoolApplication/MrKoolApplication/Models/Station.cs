namespace MrKool.Models
{
    public class Station
    {
        public int StationID { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

        // Relationships
        public ICollection<Request> RequestList { get; set; }

        public Area Area { get; set; }

        public ICollection<Technician> TechnicianList { get; set; }
    }
}
