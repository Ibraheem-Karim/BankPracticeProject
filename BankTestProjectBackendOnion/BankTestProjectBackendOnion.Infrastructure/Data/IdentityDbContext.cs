using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTestProjectBackendOnion.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankTestProjectBackendOnion.Infrastructure.Data
{
    public class IdentityDbContext : IdentityDbContext<Customer>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        // Add DbSet<T> for other entities
    }
}
