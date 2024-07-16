using MrKool.Models;
using System.Linq.Expressions;

namespace MrKoolApplication.Interface
{
    public interface IRequestRepository

    {
        Task<IEnumerable<Request>> GetAllAsync();
        Task<Request> GetRequestByIdAsync(int id);
        Request GetById(int requestID);
        Task<Request> CreateRequestAsync(Request request);
        bool UpdateRequest(Request request);    
        bool Save();

      
    }
}
