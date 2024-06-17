using MrKool.Models;
using MrKoolApplication.DTO;
using System.Linq.Expressions;

namespace MrKool.Interface
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAllAreasAsync();
        Task <Area> GetById(int areaID);
        List<Area> GetByNameContaining(string name);
        List<Area> GetByCity(string city);

        List<Area> GetAreas();
        void AddStationToArea(int areaId, StationDTO station);

        bool AreaExist(int areaID); 
        bool UpdateArea(Area area);


        bool CreateArea(Area area);

        Task DeleteAreaAsync(Area area);

        bool Save();
    }
}
