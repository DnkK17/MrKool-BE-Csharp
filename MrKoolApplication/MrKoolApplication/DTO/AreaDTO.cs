using MrKool.Models;
using MrKoolApplication.DTO;

namespace MrKool.DTO
{
    public class AreaDTO
    {
        public int AreaID { get; set; }
        public string Title { get; set; }
        public string AreaAddress { get; set; }

        public string City { get; set; }

       public List<StationDTO> Stations { get; set; }
    }
}
