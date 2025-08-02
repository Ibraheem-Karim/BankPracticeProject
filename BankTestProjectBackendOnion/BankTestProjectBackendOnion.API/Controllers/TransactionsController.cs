using BankTestProjectBackendOnion.Application.Commands;
using BankTestProjectBackendOnion.Application.DTOs.Transaction;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankTestProjectBackendOnion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("new")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto dto)
        {
            try
            {
                var command = new CreateTransactionCommand(dto);
                var result = await _mediator.Send(command);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



    }
}
