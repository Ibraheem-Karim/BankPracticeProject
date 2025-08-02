using System.Security.Claims;
using BankTestProjectBackendOnion.API.Responses;
using BankTestProjectBackendOnion.Application.DTOs.Auth;
using BankTestProjectBackendOnion.Application.Service_interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankTestProjectBackendOnion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (!result.Succeeded)
                return BadRequest(new ApiResponse<string>("Registration failed: " + string.Join(", ", result.Errors)));

            return Ok(new ApiResponse<object>(result, "User registered successfully"));
        }

        [AllowAnonymous]

        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (!result.Succeeded)
                return Unauthorized(new ApiResponse<string>("Login failed: " ));

            return Ok(new ApiResponse<object>(result, "Login successful"));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok(new ApiResponse<string>(null, "Logged out successfully"));

        }


        [Authorize]
        [HttpGet("account-number")]
        public async Task<IActionResult> GetAccountNumber()
        {
            var email = User.FindFirstValue(ClaimTypes.NameIdentifier); // Contains email
            if (string.IsNullOrEmpty(email)) return Unauthorized();

            var customerId = await _authService.GetCustomerIdByEmailAsync(email);
            if (customerId == null) return NotFound("Customer not found");


            var accountNumber = await _authService.GetAccountNumberByCustomerIdAsync(customerId);

            if (accountNumber == null)
                return NotFound(new { message = "Account not found" });

            return Ok(new { data = accountNumber });
        }


    }
}
