using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Models;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;

namespace MrKoolApplication.Models
{
    public class TechnicianRepository : ITechnicianRepository
    {

        private DBContext _context;

        private readonly IMapper _mapper;
        public TechnicianRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Technician>> GetAllTechniciansAsync()
        {
            return await _context.Technicians.ToListAsync();
        }
        public async Task<Technician> GetById(int TechnicianID)
        {
            return await _context.Technicians
                                 .FirstOrDefaultAsync(a => a.TechnicianID == TechnicianID);
        }


        public List<Technician> GetTechnicians()
        {
            return _context.Technicians.ToList();
        }


        public List<Technician> GetByNameContaining(string name)
        {
            return _context.Technicians
                           .Where(a => a.TechnicianName.Contains(name))
                           .ToList();
        }

        public List<Technician> GetByStation(int stationID)
        {
            return _context.Technicians
                           .Where(a => a.StationID == stationID)
                           .ToList();
        }

        //CRUD
        public bool TechnicianExist(int technicianID)
        {
            return _context.Set<Technician>().Any(a => a.TechnicianID == technicianID);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateTechnician(Technician technician)
        {
            _context.Add(technician);
            return Save();
        }

        public bool UpdateTechnician(Technician technician)
        {
            _context.Update(technician);
            return Save();
        }

        public async Task DeleteTechnicianAsync(Technician technician)
        {
            _context.Technicians.Remove(technician);
            await _context.SaveChangesAsync();
        }
    }
}
