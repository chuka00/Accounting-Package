using AccountManager.BLL.Interfaces;
using AccountManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.BLL.Implementation
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public Invoice CreateInvoice(int customerId, DateTime invoiceDate, DateTime dueDate, List<InvoiceLineItem> lineItems)
        {
            var invoice = new Invoice
            {
                CustomerId = customerId,
                InvoiceDate = invoiceDate,
                DueDate = dueDate,
                LineItems = lineItems
            };

            invoice.TotalAmount = lineItems.Sum(item => item.Quantity * item.UnitPrice);

            _invoiceRepository.Add(invoice);
            _invoiceRepository.SaveChanges();

            return invoice;
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            return _invoiceRepository.GetById(invoiceId);
        }

        public void RecordPayment(int invoiceId, decimal paymentAmount)
        {
            var invoice = _invoiceRepository.GetById(invoiceId);

            if (invoice != null)
            {
                invoice.PaidAmount += paymentAmount;

                if (invoice.PaidAmount >= invoice.TotalAmount)
                {
                    invoice.PaidAmount = invoice.TotalAmount;
                }

                _invoiceRepository.Update(invoice);
                _invoiceRepository.SaveChanges();
            }
        }
    }

}
