using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Models;
using MrKoolApplication.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrKoolApplication.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DBContext _context;

        public RequestRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Request>> GetAllAsync()
        {
            return await _context.Requests
                .Include(r => r.Services) // Include related entities if necessary
                .ToListAsync();
        }

        public async Task<Request> GetRequestByIdAsync(int id)
        { 
            return await _context.Requests
                .Include(r => r.Services)
                .FirstOrDefaultAsync(r => r.RequestID == id);
        }

        public Request GetById(int requestID)
        {
            return _context.Requests
                .Include(r => r.Services) // Include related entities if necessary
                .FirstOrDefault(r => r.RequestID == requestID);
        }

        public async Task<Request> CreateRequestAsync(Request request)
        {
            if (request.Services != null)
            {
                double? totalPrice = 0;

                foreach (var service in request.Services)
                {
                    totalPrice += service.Price;
                }

                request.TotalPrice = totalPrice;
            }

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public bool UpdateRequest(Request request)
        {
            _context.Requests.Update(request);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
