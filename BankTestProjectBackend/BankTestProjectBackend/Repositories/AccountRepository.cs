using BankTestProjectBackend.Data;
using BankTestProjectBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTestProjectBackend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankPracticeContext _context;

        public AccountRepository(BankPracticeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts
                .Include(a => a.Customer)
                .ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int accountId)
        {
            return await _context.Accounts
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.AccountId == accountId);
        }

        public async Task<IEnumerable<Account>> GetByCustomerIdAsync(string customerId)
        {
            return await _context.Accounts
                .Where(a => a.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }

        public void Delete(Account account)
        {
            _context.Accounts.Remove(account);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
