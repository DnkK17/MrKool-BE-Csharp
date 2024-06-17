using MrKool.Models;
using MrKoolApplication.DTO;

namespace MrKoolApplication.Interface
{
    public interface ITechnicianRepository
    {
        Task<IEnumerable<Technician>> GetAllTechniciansAsync();
        Task<Technician> GetById(int areaID);
        List<Technician> GetByNameContaining(string name);
        List<Technician> GetByStation(int stationID);

        List<Technician> GetTechnicians();
     

        bool TechnicianExist(int technicianID);
        bool UpdateTechnician(Technician technician);


        bool CreateTechnician(Technician technician);

        Task DeleteTechnicianAsync(Technician technician);

        bool Save();
    }
}
