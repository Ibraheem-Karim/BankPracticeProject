using BankTestProjectBackendOnion.Domain.Entities;
using BankTestProjectBackendOnion.Domain.Repository_interfaces;
using BankTestProjectBackendOnion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankTestProjectBackend.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Users        
                .Include(c => c.Accounts)      
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(string customerId)
        {
            return await _context.Users       
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Users       
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Users.AddAsync(customer); 
        }

        public void Update(Customer customer)
        {
            _context.Users.Update(customer);        
        }

        public void Delete(Customer customer)
        {
            _context.Users.Remove(customer);        
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}




