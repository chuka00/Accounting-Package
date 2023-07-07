using AccountManager.DAL.Entities;

namespace Accounts_Manager.Models
{
    public class AddCustomerVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
