using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Interface;
using MrKool.Models;
using MrKoolApplication.Interface;

namespace MrKool.Repository
{
    public class StationRepository : IStationRepository
    {

        private DBContext _context;

        private readonly IMapper _mapper;
        public StationRepository(DBContext context)
        {
            _context = context;
        }
        public List<Station> GetStations()
        {
            return _context.Stations.ToList();
        }
        public async Task<Station> GetById(int stationID)
        {
            return await _context.Stations.FirstOrDefaultAsync(a => a.StationID == stationID);
        }

        public List<Station> GetAll()
        {
            return _context.Stations.ToList();
        }

        public List<Station> GetByNameContaining(string name)
        {
            return _context.Set<Station>().Where(a => a.Address.Contains(name)).ToList();
        }
        //CRUD
        public bool StationExist(int StationID)
        {
            return _context.Set<Station>().Any(a => a.StationID == StationID);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateStation(Station Station)
        {
            _context.Add(Station);
            return Save();
        }

        public bool UpdateStation(Station Station)
        {
            _context.Update(Station);
            return Save();
        }

        public async Task DeleteStationAsync(Station Station)
        {
            _context.Stations.Remove(Station);
            await _context.SaveChangesAsync();
        }
    }
}

