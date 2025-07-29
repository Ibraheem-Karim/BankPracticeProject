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
            return await _context.Users        // ✅ Use Users instead of Customers
                .Include(c => c.Accounts)      // Optional: only if Accounts are correctly mapped
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(string customerId)
        {
            return await _context.Users        // ✅ Use Users
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Users        // ✅ Use Users
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Users.AddAsync(customer);  // ✅ Use Users
        }

        public void Update(Customer customer)
        {
            _context.Users.Update(customer);         // ✅ Use Users
        }

        public void Delete(Customer customer)
        {
            _context.Users.Remove(customer);         // ✅ Use Users
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}























//Old version

//using BankTestProjectBackendOnion.Domain.Entities;
//using BankTestProjectBackendOnion.Domain.Repository_interfaces;
//using BankTestProjectBackendOnion.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;

//namespace BankTestProjectBackend.Repositories
//{
//    public class CustomerRepository : ICustomerRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public CustomerRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Customer>> GetAllAsync()
//        {
//            return await _context.Customers
//                .Include(c => c.Accounts)
//                .ToListAsync();
//        }

//        public async Task<Customer?> GetByIdAsync(string customerId)
//        {
//            return await _context.Customers
//                .Include(c => c.Accounts)
//                .FirstOrDefaultAsync(c => c.Id == customerId);
//        }

//        public async Task<Customer?> GetByEmailAsync(string email)
//        {
//            return await _context.Customers
//                .FirstOrDefaultAsync(c => c.Email == email);
//        }

//        public async Task AddAsync(Customer customer)
//        {
//            await _context.Customers.AddAsync(customer);
//        }

//        public void Update(Customer customer)
//        {
//            _context.Customers.Update(customer);
//        }

//        public void Delete(Customer customer)
//        {
//            _context.Customers.Remove(customer);
//        }

//        public async Task SaveChangesAsync()
//        {
//            await _context.SaveChangesAsync();
//        }
//    }
//}
