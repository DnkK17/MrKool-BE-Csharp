using MrKool.Models;
using System.Linq.Expressions;

namespace MrKoolApplication.Interface
{
    public interface IManagerRepository
    {
        Task<List<Manager>> GetAllAsync(params Expression<Func<Manager, object>>[] includes);
        Manager GetById(int managerID);

        List<Manager> GetManagers();

        bool ManagerExist(int managerID);
        bool UpdateManager(Manager manager);

        bool CreateManager(Manager manager);

        bool DeleteManager(Manager manager);
    }
}
