using BankTestProjectBackendOnion.Domain.Entities;

namespace BankTestProjectBackendOnion.Application.Service_interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(Customer user);
    }
}
