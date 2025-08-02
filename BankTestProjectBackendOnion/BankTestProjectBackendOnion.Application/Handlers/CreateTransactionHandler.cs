using AutoMapper;
using BankTestProjectBackendOnion.Application.Commands;
using BankTestProjectBackendOnion.Domain.Entities;
using BankTestProjectBackendOnion.Domain.Repository_interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace BankTestProjectBackendOnion.Application.Handlers;

public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, string>
{
    private readonly ITransactionRepository _transactionRepo;
    private readonly IAccountRepository _accountRepo;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateTransactionHandler> _logger;

    public CreateTransactionHandler(
        ITransactionRepository transactionRepo,
        IAccountRepository accountRepo,
        IMapper mapper,
        ILogger<CreateTransactionHandler> logger)
    {
        _transactionRepo = transactionRepo;
        _accountRepo = accountRepo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<string> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        try
        {
            var fromAccount = (await _accountRepo.GetAllAsync())
                .FirstOrDefault(a => a.AccountNumber == dto.FromAccountNumber);
            var toAccount = (await _accountRepo.GetAllAsync())
                .FirstOrDefault(a => a.AccountNumber == dto.ToAccountNumber);

            if (fromAccount == null || toAccount == null)
                throw new Exception("Invalid account number(s)");

            if (fromAccount.Balance < dto.Amount)
                throw new Exception("Insufficient balance");

            // Log before transaction
            _logger.LogInformation("Initiating transaction: From {FromAccount} to {ToAccount} for {Amount} - {Description}",
                dto.FromAccountNumber, dto.ToAccountNumber, dto.Amount, dto.Description);

            fromAccount.Balance -= dto.Amount;
            toAccount.Balance += dto.Amount;

            var transaction = _mapper.Map<Transaction>(dto);
            transaction.FromAccountId = fromAccount.AccountId;
            transaction.ToAccountId = toAccount.AccountId;
            transaction.CreatedAt = DateTime.UtcNow;

            await _transactionRepo.AddAsync(transaction);
            _accountRepo.Update(fromAccount);
            _accountRepo.Update(toAccount);
            await _transactionRepo.SaveChangesAsync();

            // Log successful transaction
            _logger.LogInformation("Transaction completed successfully: {TransactionId}, From {FromAccount} to {ToAccount}, Amount: {Amount}, Time: {Time}",
                transaction.TransactionId, dto.FromAccountNumber, dto.ToAccountNumber, dto.Amount, DateTime.UtcNow);

            return "Transaction successful";
        }
        catch (Exception ex)
        {
            // Log failed transaction
            _logger.LogError(ex, "Transaction failed: From {FromAccount} to {ToAccount} for {Amount}. Error: {ErrorMessage}",
                dto.FromAccountNumber, dto.ToAccountNumber, dto.Amount, ex.Message);
            throw;
        }
    }
}