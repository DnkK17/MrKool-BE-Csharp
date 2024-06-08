using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Interface;
using MrKool.Models;

namespace MrKool.Repository
{
    public class AreaRepository : IAreaRepository
    {
         
        private DBContext _context;

        private readonly IMapper _mapper;
        public AreaRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<List<Area>> GetAllAsync(params Expression<Func<Area, object>>[] includes)
        {
        
            return await _context.Areas.Include(a => a.StationList).ToListAsync();
        }
        public Area GetById(int areaID)
        {
            return _context.Set<Area>().SingleOrDefault(a => a.AreaID == areaID);
        }

        public List<Area> GetAreas()
        {
            return _context.Areas.ToList();
        }

        
        public List<Area> GetByNameContaining(string name)
        {
            return _context.Areas.Where(a => a.Title.Contains(name)).ToList();
        }

        public List<Area> GetByCity(string city)
        {
            return _context.Areas.Where(a => a.City == city).ToList();
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

        public bool DeleteArea(Area area)
        {
            _context.Areas.Remove(area);
            return Save();
        }
    }
}
