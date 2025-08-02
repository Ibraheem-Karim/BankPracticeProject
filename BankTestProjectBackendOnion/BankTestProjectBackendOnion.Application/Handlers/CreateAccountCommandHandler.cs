using AutoMapper;
using BankTestProjectBackendOnion.Application.Commands;
using BankTestProjectBackendOnion.Domain.Entities;
using BankTestProjectBackendOnion.Domain.Repository_interfaces;
using MediatR;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public CreateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Account>(request.Dto);
        account.CreatedAt = DateTime.UtcNow;

        await _accountRepository.AddAsync(account);
        await _accountRepository.SaveChangesAsync();

        return account.AccountId;
    }
}
