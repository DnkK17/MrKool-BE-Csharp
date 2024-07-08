using MrKool.Models;

namespace MrKoolApplication.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }

        //Relationship
        public int RequestId { get; set; }
        public Request Request { get; set; }
    }
}
