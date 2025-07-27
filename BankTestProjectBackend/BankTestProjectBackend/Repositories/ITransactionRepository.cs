using BankTestProjectBackend.Models;

namespace BankTestProjectBackend.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(int accountId);
        Task AddAsync(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(Transaction transaction);
        Task SaveChangesAsync();
    }
}
