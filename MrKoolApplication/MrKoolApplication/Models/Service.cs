using MrKoolApplication.Models;
using System.Reflection;

namespace MrKool.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceTitle { get; set; }
        public string image {  get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }

        public bool IsDeleted { get; set; }
        // Relationships
        public ICollection<OrderDetail>? OrderDetailList { get; set; }


        public int? RequestID { get; set; }
        public Request? Request { get; set; }

        public int? ModelID { get; set; }
        public ConditionerModel? Model { get; set; }
    }
}
