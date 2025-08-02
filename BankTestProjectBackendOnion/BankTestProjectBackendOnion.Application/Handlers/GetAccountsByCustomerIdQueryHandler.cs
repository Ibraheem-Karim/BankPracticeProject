using AutoMapper;
using BankTestProjectBackendOnion.Application.DTOs.Account;
using BankTestProjectBackendOnion.Domain.Repository_interfaces;
using MediatR;

public class GetAccountsByCustomerIdQueryHandler : IRequestHandler<GetAccountsByCustomerIdQuery, List<AccountSummaryDto>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public GetAccountsByCustomerIdQueryHandler(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<List<AccountSummaryDto>> Handle(GetAccountsByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var accounts = await _accountRepository.GetByCustomerIdAsync(request.CustomerId);

        return _mapper.Map<List<AccountSummaryDto>>(accounts);
    }
}
