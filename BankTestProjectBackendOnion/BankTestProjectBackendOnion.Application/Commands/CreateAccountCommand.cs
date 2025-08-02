using BankTestProjectBackendOnion.Application.DTOs.Account;
using MediatR;

namespace BankTestProjectBackendOnion.Application.Commands
{
    public class CreateAccountCommand : IRequest<int>
    {
        public CreateAccountDto Dto { get; set; }

        public CreateAccountCommand(CreateAccountDto dto)
        {
            Dto = dto;
        }
    }

}
