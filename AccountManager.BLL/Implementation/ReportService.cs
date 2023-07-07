using AccountManager.BLL.Interfaces;
using AccountManager.BLL.Repository;
using AccountManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.BLL.Implementation
{
    public class ReportService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReportService(IInvoiceRepository invoiceRepository, ICustomerRepository customerRepository)
        {
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;
        }

        public List<Invoice> GetDebtsReport(DateTime startDate, DateTime endDate)
        {
            return _invoiceRepository.GetUnpaidInvoices(startDate, endDate);
        }

        public List<Customer> GetDebtorsReport()
        {
            return _customerRepository.GetDebtors();
        }

        public List<Invoice> GetInvoiceReport(int customerId)
        {
            return _invoiceRepository.GetInvoicesByCustomer(customerId);
        }
    }

}
