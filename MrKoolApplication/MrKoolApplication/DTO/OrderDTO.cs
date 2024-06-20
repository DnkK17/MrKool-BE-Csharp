using MrKool.Models;

namespace MrKoolApplication.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Address { get; set; }

        public int RequestID { get; set; }

        public int? CustomerID { get; set; }

        public ICollection<OrderDetailDTO>? OrderDetailList { get; set; }
    }
}
