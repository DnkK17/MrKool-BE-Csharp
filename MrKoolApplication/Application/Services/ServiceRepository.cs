using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Models;
using MrKoolApplication.Interface;
using System.Linq.Expressions;

namespace MrKoolApplication.Repository
{
    public class ServiceRepository : IServiceRepository
    {

        private DBContext _context;

        private readonly IMapper _mapper;
        public ServiceRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<List<Service>> GetAllAsync(params Expression<Func<Service, object>>[] includes)
        {
            IQueryable<Service> query = _context.Set<Service>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
        public Service GetById(int serviceID)
        {
            return _context.Set<Service>().SingleOrDefault(a => a.ServiceID == serviceID);
        }


        public List<Service> GetByNameContaining(string name)
        {
            return _context.Services.Where(a => a.ServiceTitle.Contains(name)).ToList();
        }

        public List<Service> GetByModel(string model)
        {
            return _context.Services.Where(a => a.Model.Title == model).ToList();
        }
    }

}
