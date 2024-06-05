using MrKool.Models;
using System.Linq.Expressions;

namespace MrKoolApplication.Interface
{
    public interface IRequestRepository

    {
        Task<List<Request>> GetAllAsync(params Expression<Func<Request, object>>[] includes);
        Request GetById(int requestID);
        bool CreateRequest(Request request);
        bool UpdateRequest(Request request);    
        bool Save();

      
    }
}
