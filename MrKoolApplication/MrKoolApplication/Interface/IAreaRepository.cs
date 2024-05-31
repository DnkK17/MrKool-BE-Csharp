using MrKool.Models;

namespace MrKool.Interface
{
    public interface IAreaRepository
    {
        Area GetById(int areaID);
        List<Area> GetAll();
        List<Area> GetByNameContaining(string name);
        List<Area> GetByCity(string city);
    }
}
