using MrKoolApplication.Enum;

namespace MrKoolApplication.DTO
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string RequestAddress { get; set; }
        public Status Status { get; set; }

        public int ConditionerModelID { get; set; }
        public int AreaID{ get; set; } 
        public int CustomerID {  get; set; }

        public int StationID { get; set; }

        public List<ServiceDTO> Services { get; set; }




    }
}
