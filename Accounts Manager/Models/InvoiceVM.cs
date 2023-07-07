namespace Accounts_Manager.Models
{
    public class InvoiceViewModel
    {
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public List<InvoiceLineItemViewModel> LineItems { get; set; }
    }
}
