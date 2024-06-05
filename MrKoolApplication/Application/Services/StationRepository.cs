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

        public Station GetById(int stationID)
        {
            return _context.Set<Station>().SingleOrDefault(a => a.StationID == stationID);
        }

        public List<Station> GetAll()
        {
            return _context.Stations.ToList();
        }

        public List<Station> GetByNameContaining(string name)
        {
            return _context.Set<Station>().Where(a => a.Address.Contains(name)).ToList();
        }
    }
}
