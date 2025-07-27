using System;
using System.Collections.Generic;

namespace BankTestProjectBackend.Models;

public partial class AspNetUserLogin
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    public string UserId { get; set; } = null!;

    public virtual Customer User { get; set; } = null!;
}
