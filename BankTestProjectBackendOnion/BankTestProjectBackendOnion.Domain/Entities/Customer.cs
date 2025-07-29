using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BankTestProjectBackendOnion.Domain.Entities
{
    public class Customer : IdentityUser
    {
        public string FullName { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();



    }
}
