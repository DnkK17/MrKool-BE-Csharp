using System.Reflection;

namespace MrKool.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceTitle { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }

        // Relationships
        public ICollection<OrderDetail>? OrderDetailList { get; set; }
        
        public Request? Request { get; set; }
        public ConditionerModel? Model { get; set; }
    }
}
