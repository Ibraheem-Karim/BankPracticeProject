using BankTestProjectBackend.Models;

namespace BankTestProjectBackend.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(Customer user);
    }

}
