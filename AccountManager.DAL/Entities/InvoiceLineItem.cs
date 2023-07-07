using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.DAL.Entities
{
    public class InvoiceLineItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineItemAmount => Quantity * UnitPrice;

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }

}
