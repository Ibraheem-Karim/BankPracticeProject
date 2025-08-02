using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTestProjectBackendOnion.Application.DTOs.Account
{
    public class CreateAccountDto
    {
        public string AccountNumber { get; set; } = null!;
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public string CustomerId { get; set; } = null!;
    }
}
