using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTestProjectBackendOnion.Application.DTOs.Transaction;
using MediatR;

namespace BankTestProjectBackendOnion.Application.Commands
{
    public class CreateTransactionCommand : IRequest<string>
    {
        public CreateTransactionDto Dto { get; set; }

        public CreateTransactionCommand(CreateTransactionDto dto)
        {
            Dto = dto;
        }
    }

}
