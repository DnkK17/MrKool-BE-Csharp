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
            IQueryable<Area> query = _context.Set<Area>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
        public Area GetById(int areaID)
        {
            return _context.Set<Area>().SingleOrDefault(a => a.AreaID == areaID);
        }

        public List<Area> GetAll()
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
    }
}
