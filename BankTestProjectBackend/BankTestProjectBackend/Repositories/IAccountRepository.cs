using BankTestProjectBackend.Models;

namespace BankTestProjectBackend.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(int accountId);
        Task<IEnumerable<Account>> GetByCustomerIdAsync(string customerId);
        Task AddAsync(Account account);
        void Update(Account account);
        void Delete(Account account);
        Task SaveChangesAsync();
    }
}
