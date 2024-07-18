using MrKool.Models;

namespace MrKoolApplication.DTO
{
    public class ConditionerModelDTO
    {
        public int ConditionerModelID { get; set; }
        public string Title { get; set; }
        public String image { get; set; }
        public List<ServiceDTO>? Services { get; set; }

    }
}
