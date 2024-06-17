using MrKool.Models;

namespace MrKoolApplication.Models
{
    public class FixHistoryService
    {
        public int FixHistoryID { get; set; }
        public FixHistory FixHistory { get; set; }

        public int ServiceID { get; set; }
        public Service Service { get; set; }
        public bool IsDeleted { get; set; }
    }
}
