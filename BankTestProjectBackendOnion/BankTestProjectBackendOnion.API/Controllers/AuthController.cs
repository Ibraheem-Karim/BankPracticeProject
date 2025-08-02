using BankTestProjectBackendOnion.Application.DTOs.Auth;
using BankTestProjectBackendOnion.Application.Service_interfaces;
using BankTestProjectBackendOnion.API.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankTestProjectBackendOnion.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (!result.Succeeded)
                return BadRequest(new ApiResponse<string>("Registration failed: " + string.Join(", ", result.Errors)));

            return Ok(new ApiResponse<object>(result, "User registered successfully"));
        }

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
    }
}
