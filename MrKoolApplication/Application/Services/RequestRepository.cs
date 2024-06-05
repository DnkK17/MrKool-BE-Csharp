using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Models;
using MrKoolApplication.Interface;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace MrKoolApplication.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private DBContext _context;

        private readonly IMapper _mapper;

        public RequestRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Request>> GetAllAsync(params Expression<Func<Request, object>>[] includes)
        {
            IQueryable<Request> query = _context.Set<Request>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public Request GetById(int requestID)
        {
            return _context.Set<Request>().SingleOrDefault(a => a.RequestID == requestID);
        }

        public bool CreateRequest(Request request)
        {
            _context.Set<Request>().Add(request);
            return Save();
        }


        public bool UpdateRequest(Request request)
        {
            _context.Update(request);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


    }
}
