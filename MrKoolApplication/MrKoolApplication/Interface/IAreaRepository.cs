using MrKool.Models;
using MrKoolApplication.DTO;
using System.Linq.Expressions;

namespace MrKool.Interface
{
    public interface IAreaRepository
    {
        Task<List<Area>> GetAllAsync(params Expression<Func<Area, object>>[] includes);
        Area GetById(int areaID);
        List<Area> GetByNameContaining(string name);
        List<Area> GetByCity(string city);

        List<Area> GetAreas();

        bool AreaExist(int areaID); 
        bool UpdateArea(Area area);

        bool CreateArea(Area area);

        bool DeleteArea(Area area);
    }
}
