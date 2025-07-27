using System;
using System.Collections.Generic;

namespace BankTestProjectBackend.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public string TransactionType { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
