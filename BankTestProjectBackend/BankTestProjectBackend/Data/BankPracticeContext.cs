using System;
using System.Collections.Generic;
using BankTestProjectBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankTestProjectBackend.Data;

public partial class BankPracticeContext : IdentityDbContext<Customer>
{
    public BankPracticeContext(DbContextOptions<BankPracticeContext> options)
        : base(options)
    {
    }

    // Only your custom DbSets (Identity tables are handled by the base class)
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Move this to appsettings.json in production!
            optionsBuilder.UseSqlServer("Server=DESKTOP-EC6JSRR;Database=BankPracticeDB;User Id=sa;Password=EbrahimDX9330;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Essential for Identity configuration

        // Configure Account entity
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId)
                .HasName("PK__Account__349DA5A6A3F7916F");

            entity.ToTable("Account");

            entity.HasIndex(e => e.CustomerId, "IX_Account_CustomerId");
            entity.HasIndex(e => e.AccountNumber, "UQ__Account__BE2ACD6F31A62223")
                .IsUnique();

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20);
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(19, 4)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true);

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Account_Customer");
        });

        // Configure Transaction entity
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId)
                .HasName("PK__Transact__55433A6B06E2C564");

            entity.ToTable("Transaction");

            entity.HasIndex(e => e.AccountId, "IX_Transaction_AccountId");

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(19, 4)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(255);
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50);

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Transaction_Account");
        });

        // Configure Customer entity (only customizations, no Identity mappings)
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            // Custom properties (IdentityUser properties are handled by base)
            entity.Property(e => e.FullName)
                .HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId)
                .IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
