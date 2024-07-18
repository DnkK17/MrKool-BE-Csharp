namespace MrKool.Models
{
    public class ConditionerModel
    {
        public int ConditionerModelID { get; set; }
        public string? Title { get; set; }
        public string? image { get; set; }
        public bool? Status { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;
        // Relationship

        public List<Request>? RequestList { get; set; }
        public List<Service>? Services { get; set; }
    }
}
