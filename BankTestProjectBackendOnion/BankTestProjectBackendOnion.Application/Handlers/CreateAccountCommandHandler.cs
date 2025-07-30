using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTestProjectBackendOnion.Application.Commands;
using BankTestProjectBackendOnion.Domain.Entities;
using BankTestProjectBackendOnion.Domain.Repository_interfaces;
using MediatR;

namespace BankTestProjectBackendOnion.Application.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var newAccount = new Account
            {
                AccountNumber = request.AccountNumber,
                Balance = request.InitialBalance,
                CustomerId = request.CustomerId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _accountRepository.AddAsync(newAccount);
            await _accountRepository.SaveChangesAsync();

            return newAccount.AccountId;
        }
    }
}
