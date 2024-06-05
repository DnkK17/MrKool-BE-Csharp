namespace MrKoolApplication.DTO
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string RequestAddress { get; set; }
        public string Status { get; set; }

        public int AreaID{ get; set; }

        public string AreaAddress { get; set; }   
        public int CustomerID {  get; set; }

        public int StationID { get; set; }

        public string Address { get; set; }
        public string CustomerName { get; set; }

        public int ServiceID { get; set; }

        public string ServiceTitle { get; set; }
    }
}
