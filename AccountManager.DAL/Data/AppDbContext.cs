using AccountManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>()
                .Property(i => i.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .Property(p => p.TotalAmount)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Invoice>()
               .Property(p => p.PaidAmount)
               .HasPrecision(18, 2);
            modelBuilder.Entity<InvoiceLineItem>()
                .Property(p => p.Quantity)
                .HasPrecision(18, 2);
            modelBuilder.Entity<InvoiceLineItem>()
                .Property(p => p.UnitPrice)
                .HasPrecision(18, 2);

            // Rest of your model configuration
        }

    }
}
