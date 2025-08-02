using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTestProjectBackendOnion.Application.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = null!;
        public string? Description { get; set; }
        public string FromAccountNumber { get; set; } = null!;
        public string ToAccountNumber { get; set; } = null!;
    }

}
