using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessStudioApp
{
    public class FitnessStudioContext : DbContext
    {
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<FitnessClass> FitnessClasses { get; set; }

        public FitnessStudioContext()
        {

        }
        public FitnessStudioContext(DbContextOptions<FitnessStudioContext> options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = FitnessStudiodbJan20; Integrated Security=True;Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAccount>(entity =>
            {
                entity.ToTable("CustomerAccounts")
                .HasKey(e => e.CustomerID)
                .HasName("PK_CustomerAccounts");
                entity.Property(e => e.CustomerID)
                .IsRequired()
                .ValueGeneratedOnAdd();
                entity.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(e => e.CustomerName)
                .IsRequired();
                entity.Property(e => e.CustomerPhone)
                .IsRequired();
                entity.Property(e => e.DateofBirth)
                .IsRequired();
                entity.Property(e => e.CustomerSince)
                .ValueGeneratedOnAdd();

            });

            modelBuilder.Entity<Transaction>(entity =>
            {
               entity.ToTable("Transactions");
               entity.HasKey(e => e.TransactionID)
               .HasName("PK_Transactions");

               entity.Property(e => e.TransactionID)
               .ValueGeneratedOnAdd();

               entity.Property(e => e.Amount)
               .IsRequired();

               entity.HasOne(e => e.CustomerAccount)
               .WithMany()
               .HasForeignKey(e => e.CustomerID);
            });
            modelBuilder.Entity<FitnessClass>(entity =>
            {
                entity.ToTable("FitnessClasses");
                entity.HasKey(e => e.ClassTitle)
                .HasName("PK_ClassTitle");
            });
        }
    }
}
