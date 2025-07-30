using MediatR;

namespace BankTestProjectBackendOnion.Application.Commands
{
    public class CreateAccountCommand : IRequest<int> // returns AccountId
    {
        public string AccountNumber { get; set; } = null!;
        public decimal InitialBalance { get; set; }
        public string CustomerId { get; set; } = null!;
    }
}
