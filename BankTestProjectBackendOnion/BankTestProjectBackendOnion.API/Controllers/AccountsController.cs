using BankTestProjectBackendOnion.Application.Commands;
using BankTestProjectBackendOnion.Application.DTOs.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto dto)
        {
            var command = new CreateAccountCommand(dto);
            var newAccountId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetLatestAccountById), new { id = newAccountId }, newAccountId);
        }

        // Optional: stub for GetAccountById so the route works
        [HttpGet("{id}")]
        public IActionResult GetLatestAccountById(int id)
        {
            return Ok();
        }

        [HttpGet("by-customer/{customerId}")]
        
        public async Task<IActionResult> GetAccountsByCustomerId(string customerId)
        {
            var result = await _mediator.Send(new GetAccountsByCustomerIdQuery(customerId));
            return Ok(result);
        }

    }
}
