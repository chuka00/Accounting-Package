using AccountManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.BLL.Interfaces
{
    public interface IInvoiceRepository
    {
        Invoice GetById(int id);
        List<Invoice> GetUnpaidInvoices(DateTime startDate, DateTime endDate);
        List<Invoice> GetInvoicesByCustomer(int customerId);
        void Add(Invoice invoice);
        void Update(Invoice invoice);
        void SaveChanges();
    }
}
