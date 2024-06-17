using MrKool.Models;
using System.Linq.Expressions;

namespace MrKoolApplication.Interface
{
    public interface IRequestRepository

    {
        Task<IEnumerable<Request>> GetAllAsync();
        Request GetById(int requestID);
        bool CreateRequest(Request request);
        bool UpdateRequest(Request request);    
        bool Save();

      
    }
}
