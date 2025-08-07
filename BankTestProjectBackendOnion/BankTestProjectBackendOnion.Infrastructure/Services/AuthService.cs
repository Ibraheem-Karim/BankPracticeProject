using AutoMapper;
using BankTestProjectBackendOnion.Application.DTOs.Auth;
using BankTestProjectBackendOnion.Application.Service_interfaces;
using BankTestProjectBackendOnion.Domain.Entities;
using BankTestProjectBackendOnion.Domain.Repository_interfaces;
using Microsoft.AspNetCore.Identity;

namespace BankTestProjectBackendOnion.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AuthService(
            UserManager<Customer> userManager,
            SignInManager<Customer> signInManager,
            IJwtTokenGenerator jwtTokenGenerator,
            IMapper mapper,
            IAccountRepository accountRepository) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        

        public async Task<AuthResultDto> RegisterAsync(RegisterDto dto)
        {
            var user = _mapper.Map<Customer>(dto);


            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return new AuthResultDto
                {
                    Succeeded = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }

            var token = _jwtTokenGenerator.GenerateJwtToken(user);

            return new AuthResultDto
            {
                Succeeded = true,
                Token = token
            };
        }

        public async Task<AuthResultDto> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return new AuthResultDto
                {
                    Succeeded = false,
                    Errors = new[] { "Invalid credentials" }
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded)
            {
                return new AuthResultDto
                {
                    Succeeded = false,
                    Errors = new[] { "Invalid credentials" }
                };
            }

            var token = _jwtTokenGenerator.GenerateJwtToken(user);

            return new AuthResultDto
            {
                Succeeded = true,
                Token = token
            };
        }

        public Task LogoutAsync()
        {
           
            return Task.CompletedTask;
        }

        public async Task<string?> GetAccountNumberByCustomerIdAsync(string customerId)
        {
            var accounts = await _accountRepository.GetByCustomerIdAsync(customerId);

            var latestActiveAccount = accounts?
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.CreatedAt)
                .FirstOrDefault();

            return latestActiveAccount?.AccountNumber;
        }

        public async Task<string?> GetCustomerIdByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user?.Id;
        }



    }
}
