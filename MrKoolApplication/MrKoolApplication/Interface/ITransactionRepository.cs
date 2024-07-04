using MrKool.Models;
using MrKoolApplication.DTO;

namespace MrKoolApplication.Interface
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task<Transaction> GetById(int transactionID);
        List<Transaction> GetByDate(DateTime Date);

        List<Transaction> GetTransactions();

        bool TransactionExist(int transactionID);
        bool UpdateTransaction(Transaction transaction);

        Task DeleteTransactionAsync(Transaction transaction);

        bool Save();
    }
}
