using AccountManager.BLL.Interfaces;
using AccountManager.DAL.Data;
using AccountManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.BLL.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Invoice GetById(int id)
        {
            return _dbContext.Invoices.Include(i => i.Customer).FirstOrDefault(i => i.Id == id);
        }

        public List<Invoice> GetUnpaidInvoices(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Invoices.Include(i => i.Customer)
                .Where(i => i.DueDate >= startDate && i.DueDate <= endDate && i.PaidAmount < i.TotalAmount)
                .ToList();
        }

        public List<Invoice> GetInvoicesByCustomer(int customerId)
        {
            return _dbContext.Invoices.Include(i => i.Customer)
                .Where(i => i.CustomerId == customerId)
                .ToList();
        }

        public void Add(Invoice invoice)
        {
            _dbContext.Invoices.Add(invoice);
        }

        public void Update(Invoice invoice)
        {
            _dbContext.Invoices.Update(invoice);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }

}
