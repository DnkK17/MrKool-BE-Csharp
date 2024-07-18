using MrKoolApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MrKool.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }
        public string? ServiceTitle { get; set; }
        public string? image {  get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }

        public bool? Status { get; set; } = true;

        public bool? IsDeleted { get; set; } = false;
        // Relationships
        public ICollection<OrderDetail>? OrderDetailList { get; set; }


        public int? RequestID { get; set; }
        public Request? Request { get; set; }

        public int? ConditionalModelID { get; set; }

        public ConditionerModel? Model { get; set; }
    }
}
