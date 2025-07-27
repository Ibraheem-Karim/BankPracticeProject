using System;
using System.Collections.Generic;

namespace BankTestProjectBackend.Models;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual Customer User { get; set; } = null!;
}
