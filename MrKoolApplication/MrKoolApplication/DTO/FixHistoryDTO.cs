using MrKool.Models;

namespace MrKoolApplication.DTO
{
    public class FixHistoryDTO
    {
        public int FixHistoryID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public int TechnicianID { get; set; }
        public string TechnicianName { get; set; }

        public int CustomerID { get; set; }

        public Customer CustomerName { get; set; }

        public int ServiceID { get; set; }

        public Service ServiceTitle { get; set; }
    }
}
