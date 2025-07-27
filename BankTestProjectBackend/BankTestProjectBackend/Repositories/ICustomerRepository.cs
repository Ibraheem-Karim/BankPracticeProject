using BankTestProjectBackend.Models;

namespace BankTestProjectBackend.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(string customerId);
        Task<Customer?> GetByEmailAsync(string email);
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task SaveChangesAsync();
    }
}
