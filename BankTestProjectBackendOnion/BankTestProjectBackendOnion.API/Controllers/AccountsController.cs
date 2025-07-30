using BankTestProjectBackendOnion.Application.Commands;
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace BankTestProjectBackendOnion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var accountId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLatestAccountById), new { id = accountId }, null);
        }

        // Optional: stub for GetAccountById so the route works
        [HttpGet("{id}")]
        public IActionResult GetLatestAccountById(int id)
        {
            return Ok();
        }
    }
}
