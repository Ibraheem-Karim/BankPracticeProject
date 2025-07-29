using AutoMapper;
using BankTestProjectBackendOnion.Application.DTOs.Auth;
using BankTestProjectBackendOnion.Domain.Entities;

namespace BankTestProjectBackendOnion.Application.Mappings
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            // Map RegisterDto → Customer
            CreateMap<RegisterDto, Customer>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
        }
    }
}
