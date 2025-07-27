using BankTestProjectBackend.Data;
using BankTestProjectBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTestProjectBackend.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankPracticeContext _context;

        public CustomerRepository(BankPracticeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(string customerId)
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
