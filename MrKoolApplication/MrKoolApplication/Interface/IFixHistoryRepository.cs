using MrKool.Models;
using System.Linq.Expressions;

namespace MrKoolApplication.Interface
{
    public interface IFixHistoryRepository
    {
        Task<IEnumerable<FixHistory>> GetAllFixHistorysAsync();
        Task<FixHistory> GetById(int fixHistoryID);
        List<FixHistory> GetByCustomerID(int CustomerID);

        List<FixHistory> GetFixHistories();

        bool FixHistoryExist(int FixHistoryID);
        bool UpdateFixHistory(FixHistory fixHistory);


        bool CreateFixHistory(FixHistory fixHistory);

        Task DeleteFixHistoryAsync(FixHistory fixHistory);

        bool Save();
    }
}
