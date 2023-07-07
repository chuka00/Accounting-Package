using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DAL.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public bool IsPaid => PaidAmount >= TotalAmount;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<InvoiceLineItem> LineItems { get; set; }
    }

}
