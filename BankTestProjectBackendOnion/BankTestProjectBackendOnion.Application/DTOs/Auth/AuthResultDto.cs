using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTestProjectBackendOnion.Application.DTOs.Auth
{
    public class AuthResultDto
    {
        public bool Succeeded { get; set; }
        public string? Token { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
