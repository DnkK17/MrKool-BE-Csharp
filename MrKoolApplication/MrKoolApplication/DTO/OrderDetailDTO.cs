using MrKool.Models;

namespace MrKoolApplication.DTO
{
    public class OrderDetailDTO
    {
        public string Image { get; set; }

        public bool Status { get; set; }
        public bool IsDeleted { get; set; }


        // Relationships
        public int OrderID { get; set; }

        public int TechnicianID { get; set; }
        public int ServiceID { get; set; }

    }
}
