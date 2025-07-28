using System;
using System.Collections.Generic;

namespace BankTestProjectBackendOnion.Domain.Entities;

public partial class Account
{
    public int AccountId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public decimal Balance { get; set; }

    public string CustomerId { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
