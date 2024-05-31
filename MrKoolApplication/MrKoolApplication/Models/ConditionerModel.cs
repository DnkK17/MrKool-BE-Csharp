namespace MrKool.Models
{
    public class ConditionerModel
    {
        public int ConditionerModelID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        // Relationship
        public ICollection<Service> ServiceList { get; set; }
    }
}
