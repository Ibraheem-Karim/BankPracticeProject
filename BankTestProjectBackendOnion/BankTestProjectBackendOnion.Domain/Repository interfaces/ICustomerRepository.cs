using BankTestProjectBackendOnion.Domain.Entities;

namespace BankTestProjectBackendOnion.Domain.Repository_interfaces
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
