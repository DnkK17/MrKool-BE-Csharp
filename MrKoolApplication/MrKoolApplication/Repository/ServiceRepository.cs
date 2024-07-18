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

        public List<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        //CRUD
        public bool ServiceExist(int serviceID)
        {
            return _context.Set<Service>().Any(a => a.ServiceID == serviceID);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateService(Service Service)
        {
            _context.Add(Service);
            return Save();
        }

        public bool UpdateService(Service Service)
        {
            _context.Update(Service);
            return Save();
        }

        public async Task DeleteServiceAsync(Service Service)
        {
            _context.Services.Remove(Service);
            await _context.SaveChangesAsync();
        }
    }

}
