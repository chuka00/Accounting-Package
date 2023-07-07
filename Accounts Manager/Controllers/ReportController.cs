using AccountManager.DAL.Data;
using AccountManager.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accounts_Manager.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReportController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /*public IActionResult DebtsReport(DateTime startDate, DateTime endDate)
        {
            var debts = _context.Invoices
                .Where(i => i.InvoiceDate >= startDate && i.InvoiceDate <= endDate)
                .GroupBy(i => i.CustomerId)
                .Select(g => new DebtReportItem
                {
                    CustomerName = g.First().Customer.Name,
                    TotalDebt = g.Sum(i => i.TotalAmount - i.PaidAmount)
                })
                .ToList();

            return View(debts);
        }*/
        public IActionResult DebtsReport(DateTime startDate, DateTime endDate)
        {
            var debts = _context.Invoices
                .Where(i => i.InvoiceDate >= startDate && i.InvoiceDate <= endDate)
                .GroupBy(i => i.CustomerId)
                .Select(g => new DebtReportItem
                {
                    CustomerName = g.First().Customer.Name,
                    TotalDebt = g.Sum(i => i.TotalAmount - i.PaidAmount)  // Calculate the remaining debt amount
                })
                .ToList();

            return View(debts);
        }

        public IActionResult DebtorsReport()
        {
            var debtors = _context.Customers
                .Where(c => c.Invoices.Any(i => i.TotalAmount > i.PaidAmount))  // Check if there are any unpaid invoices
                .ToList();

            return View(debtors);
        }


        /* public IActionResult DebtorsReport()
         {
             var debtors = _context.Customers
                 .Where(c => c.Invoices.Any(i => i.TotalAmount > i.PaidAmount))
                 .ToList();

             return View(debtors);
         }*/

        public IActionResult InvoiceReport(int invoiceId)
        {
            var invoice = _context.Invoices
                .Include(i => i.Customer)
                .FirstOrDefault(i => i.Id == invoiceId);

            if (invoice == null)
                return NotFound();

            return View(invoice);
        }

        /*public class ReportController : Controller


   
}
*/
    }
}
