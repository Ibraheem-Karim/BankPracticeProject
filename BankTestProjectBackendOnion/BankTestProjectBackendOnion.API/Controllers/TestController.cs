using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankTestProjectBackendOnion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // Open endpoint (no auth required)
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok(new
            {
                Message = "This is a public endpoint - no token required",
                Timestamp = DateTime.UtcNow
            });
        }

        // Protected endpoint (requires valid JWT)
        [Authorize]
        [HttpGet("protected")]
        public IActionResult ProtectedEndpoint()
        {
            // Extract user claims from the validated JWT
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(new
            {
                Message = "This is a PROTECTED endpoint - only accessible with valid JWT",
                UserId = userId,
                UserEmail = userEmail,
                YourClaims = User.Claims.Select(c => new { c.Type, c.Value }),
                Timestamp = DateTime.UtcNow
            });
        }

        // Admin-only endpoint (requires JWT + "Admin" role)
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminEndpoint()
        {
            return Ok(new
            {
                Message = "This is an ADMIN ONLY endpoint",
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
