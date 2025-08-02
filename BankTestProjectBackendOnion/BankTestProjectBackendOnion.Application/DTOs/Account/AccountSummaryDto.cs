namespace BankTestProjectBackendOnion.Application.DTOs.Account;

public class AccountSummaryDto
{
    public string AccountNumber { get; set; } = null!;
    public decimal Balance { get; set; }
    public int TransactionCount { get; set; }
    public DateTime CreatedAt { get; set; }
}
