using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BankTestProjectBackend.Models;

public partial class Customer: IdentityUser
{
    public string FullName { get; set; } = null!;
    

    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CustomerId { get; set; } = null!;

   

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    
}
