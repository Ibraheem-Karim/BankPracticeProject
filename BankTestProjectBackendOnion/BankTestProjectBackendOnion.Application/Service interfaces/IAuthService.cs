using BankTestProjectBackendOnion.Application.DTOs.Auth;

namespace BankTestProjectBackendOnion.Application.Service_interfaces
{
    public interface IAuthService
    {
        Task<AuthResultDto> RegisterAsync(RegisterDto dto);
        Task<AuthResultDto> LoginAsync(LoginDto dto);
        Task LogoutAsync();

        Task<string?> GetAccountNumberByCustomerIdAsync(string customerId);

        Task<string?> GetCustomerIdByEmailAsync(string email);

    }
}