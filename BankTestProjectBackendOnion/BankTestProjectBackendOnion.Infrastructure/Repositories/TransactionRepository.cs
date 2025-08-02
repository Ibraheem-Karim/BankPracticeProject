using BankTestProjectBackendOnion.Domain.Entities;
using BankTestProjectBackendOnion.Domain.Repository_interfaces;
using BankTestProjectBackendOnion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankTestProjectBackend.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions
                .Include(t => t.FromAccount)
                .Include(t => t.ToAccount)
                .ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(int transactionId)
        {
            return await _context.Transactions
                .Include(t => t.FromAccount)
                .Include(t => t.ToAccount)
                .FirstOrDefaultAsync(t => t.TransactionId == transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(int accountId)
        {
            return await _context.Transactions
                .Where(t => t.FromAccountId == accountId || t.ToAccountId == accountId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public void Update(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
        }

        public void Delete(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
