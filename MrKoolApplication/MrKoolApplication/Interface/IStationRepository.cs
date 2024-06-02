using MrKool.Models;

namespace MrKoolApplication.Interface
{
    public interface IStationRepository
    {
        Station GetById(int stationID);
        List<Station> GetAll();
        List<Station> GetByNameContaining(string name);
    }
}
