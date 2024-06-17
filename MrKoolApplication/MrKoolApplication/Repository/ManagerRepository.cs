using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Models;
using MrKoolApplication.Interface;
using System.Linq.Expressions;

namespace MrKoolApplication.Repository
{
    public class ManagerRepository : IManagerRepository
    {

        private DBContext _context;

        private readonly IMapper _mapper;
        public ManagerRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Manager>> GetAllAsync(params Expression<Func<Manager, object>>[] includes)
        {

            return await _context.Managers.Include(a => a.StationList).ToListAsync();
        }

        public Manager GetById(int managerID)
        {
            return _context.Set<Manager>().SingleOrDefault(a => a.ManagerID == managerID);
        }

        public List<Manager> GetManagers()
        {
            return _context.Managers.ToList();
        }


     

      

        //CRUD
        public bool ManagerExist(int managerID)
        {
            return _context.Set<Manager>().Any(a => a.ManagerID == managerID);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateManager(Manager manager)
        {
            _context.Add(manager);
            return Save();
        }

        public bool UpdateManager(Manager manager)
        {
            _context.Update(manager);
            return Save();
        }

        public bool DeleteManager(Manager manager)
        {
            _context.Managers.Remove(manager);
            return Save();
        }
    }
}

