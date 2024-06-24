using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Models;
using MrKoolApplication.Interface;
using System.Linq.Expressions;

namespace MrKoolApplication.Repository
{
    public class FixHistoryRepository : IFixHistoryRepository
    {
        private DBContext _context;

        private readonly IMapper _mapper;
        public FixHistoryRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FixHistory>> GetAllFixHistorysAsync()
        {
            return await _context.FixHistories.ToListAsync();
        }
        public List<FixHistory> GetByCustomerID(int customerID)
        {
            return  _context.FixHistories
                                 .Where(f => f.CustomerID==customerID)
                                 .ToList();
         
        }

        public async Task<FixHistory> GetById(int fixHistoryID)
        {
            return await _context.FixHistories.FirstOrDefaultAsync(f => f.FixHistoryID == fixHistoryID);
        }

        public List<FixHistory> GetFixHistories()
        {
            return _context.FixHistories.ToList();
        }

        //CRUD
        public bool FixHistoryExist(int FixHistoryID)
        {
            return _context.Set<FixHistory>().Any(a => a.FixHistoryID == FixHistoryID);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateFixHistory(FixHistory fixHistory)
        {
            _context.Add(fixHistory);
            return Save();
        }

        public bool UpdateFixHistory(FixHistory fixHistory)
        {
            _context.Update(fixHistory);
            return Save();
        }

        public async Task DeleteFixHistoryAsync(FixHistory fixHistory)
        {
            _context.FixHistories.Remove(fixHistory);
            await _context.SaveChangesAsync();
        }
    }
}
