using System;
using System.Collections.Generic;

namespace BankTestProjectBackendOnion.Domain.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public decimal Amount { get; set; }

    public string TransactionType { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public int FromAccountId { get; set; }
    public int ToAccountId { get; set; }


    public virtual Account FromAccount { get; set; } = null!;
    public virtual Account ToAccount { get; set; } = null!;
}
