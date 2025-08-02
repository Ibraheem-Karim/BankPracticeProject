using AutoMapper;
using BankTestProjectBackendOnion.Application.DTOs;
using BankTestProjectBackendOnion.Application.DTOs.Transaction;
using BankTestProjectBackendOnion.Domain.Entities;

namespace BankTestProjectBackendOnion.Application.Mappings;

public class TransactionMappingProfile : Profile
{
    public TransactionMappingProfile()
    {
        CreateMap<CreateTransactionDto, Transaction>()
            .ForMember(dest => dest.FromAccountId, opt => opt.Ignore())
            .ForMember(dest => dest.ToAccountId, opt => opt.Ignore())
            .ForMember(dest => dest.TransactionId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.FromAccount, opt => opt.Ignore())
            .ForMember(dest => dest.ToAccount, opt => opt.Ignore());
    }
}
