using MrKool.Models;

namespace MrKoolApplication.DTO
{
    public class ConditionerModelDTO
    {
        public int ConditionerModelID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public String image { get; set; }

        public string image { get; set; }
        public List<Service> Services { get; set; }
    }
}
