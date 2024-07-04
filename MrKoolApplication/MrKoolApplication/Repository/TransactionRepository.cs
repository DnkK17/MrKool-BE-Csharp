using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MrKool.Data;
using MrKool.Models;
using MrKoolApplication.DTO;
using MrKoolApplication.Interface;

namespace MrKoolApplication.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private DBContext _context;

        private readonly IMapper _mapper;

        public TransactionRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }
        public async Task<Transaction> GetById(int TransactionID)
        {
            return await _context.Transactions
                                 .FirstOrDefaultAsync(a => a.TransactionID == TransactionID);
        }
        public List<Transaction> GetTransactions()
        {
            return _context.Transactions.ToList();
        }
        public List<Transaction> GetByDate(DateTime date)
        {
            return _context.Transactions
                .Where(t => t.Date.Date == date.Date)
                .Select(t => new Transaction
                {
                    TransactionID = t.TransactionID,
                    Amount = t.Amount,
                    Date = t.Date
                }).ToList();
        }

        //CRUD
        public bool TransactionExist(int transactionID)
        {
            return _context.Set<Transaction>().Any(a => a.TransactionID == transactionID);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        

        public bool UpdateTransaction(Transaction Transaction)
        {
            _context.Update(Transaction);
            return Save();
        }

        public async Task DeleteTransactionAsync(Transaction Transaction)
        {
            _context.Transactions.Remove(Transaction);
            await _context.SaveChangesAsync();
        }
    }
}
