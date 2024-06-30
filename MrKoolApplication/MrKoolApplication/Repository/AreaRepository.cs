using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Interface;
using MrKool.Models;
using MrKoolApplication.DTO;

namespace MrKool.Repository
{
    public class AreaRepository : IAreaRepository
    {
         
        private DBContext _context;

        private readonly IMapper _mapper;
        public AreaRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Area>> GetAllAreasAsync()
        {
            return await _context.Areas.Include(a => a.StationList).ToListAsync();
        }
        public async Task<Area> GetById(int areaID)
        {
            return await _context.Areas
                                 .Include(a => a.StationList)
                                 .FirstOrDefaultAsync(a => a.AreaID == areaID);
        }


        public List<Area> GetAreas()
        {
            return _context.Areas.ToList();
        }


        public List<Area> GetByNameContaining(string name)
        {
            return _context.Areas
                           .Include(a => a.StationList)
                           .Where(a => a.Title.Contains(name))
                           .ToList();
        }

        public List<Area> GetByCity(string city)
        {
            return _context.Areas
                           .Include(a => a.StationList)
                           .Where(a => a.City == city)
                           .ToList();
        }
        public void AddStationToArea(int areaId, StationDTO stationDto)
        {
            var area = GetById(areaId);
            if (area != null)
            {
                var station = _mapper.Map<Station>(stationDto);
                station.AreaID = areaId;
                _context.Stations.Add(station);
            }
        }

        //CRUD
        public bool AreaExist(int areaID)
        {
            return _context.Set<Area>().Any(a => a.AreaID == areaID);
        }
        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateArea(Area area)
        {
            _context.Add(area);
            return Save();
        }

        public bool UpdateArea(Area area)
        {
            _context.Update(area);
            return Save();
        }

        public async Task DeleteAreaAsync(Area area)
        {
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
        }
    }
}
