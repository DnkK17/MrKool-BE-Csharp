using MrKool.Models;
using System.Linq.Expressions;

namespace MrKoolApplication.Interface
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllAsync(params Expression<Func<Service, object>>[] includes);
        Service GetById(int serviceID);
        List<Service> GetByNameContaining(string name);
        
    }
}
