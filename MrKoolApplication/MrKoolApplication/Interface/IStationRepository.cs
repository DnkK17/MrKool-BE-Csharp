using MrKool.Models;

namespace MrKoolApplication.Interface
{
    public interface IStationRepository
    {
        Task <Station> GetById(int stationID);
        List<Station> GetAll();

        List<Station> GetStations();
        List<Station> GetByNameContaining(string name);
        bool StationExist(int areaID);
        bool UpdateStation(Station station);


        bool CreateStation(Station station);

        Task DeleteStationAsync(Station station);

        bool Save();
    }
}
