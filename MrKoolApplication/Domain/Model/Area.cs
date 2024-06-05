using static System.Collections.Specialized.BitVector32;

namespace MrKool.Models
{
    public class Area
    {
        public int AreaID { get; set; }
        public string Title { get; set; }
        public string AreaAddress { get; set; }

        public string City { get; set; }    

        // Relationship
        public ICollection<Customer> CustomerList { get; set; }
        public List<Station> StationList { get; set; }
        public ICollection<Request> RequestList { get; set; }
    }
}
