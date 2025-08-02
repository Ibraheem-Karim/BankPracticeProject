using MediatR;
using BankTestProjectBackendOnion.Application.DTOs.Account;

public class GetAccountsByCustomerIdQuery : IRequest<List<AccountSummaryDto>>
{
    public string CustomerId { get; }

    public GetAccountsByCustomerIdQuery(string customerId)
    {
        CustomerId = customerId;
    }
}
