using AccountManager.BLL.Implementation;
using AccountManager.DAL.Entities;
using Accounts_Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Accounts_Manager.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public IActionResult Create()
        {
            // Return the view for creating a new invoice
            return View();
        }

        [HttpPost]
        public IActionResult Create(InvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map the view model data to domain model
                var lineItems = model.LineItems.Select(item => new InvoiceLineItem
                {
                    Description = item.Description,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList();

                // Create the invoice
                var invoice = _invoiceService.CreateInvoice(model.CustomerId, model.InvoiceDate, model.DueDate, lineItems);

                // Redirect to the invoice details page
                return RedirectToAction("Details", new { id = invoice.Id });
            }

            // If the model is invalid, return the view with validation errors
            return View(model);
        }

        public IActionResult Details(int id)
        {
            // Retrieve the invoice by id
            var invoice = _invoiceService.GetInvoiceById(id);

            if (invoice == null)
            {
                // Return a not found view or redirect to an error page
                return NotFound();
            }

            // Return the view with the invoice details
            return View(invoice);
        }

        public IActionResult RecordPayment(int id, decimal paymentAmount)
        {
            // Record payment for the invoice
            _invoiceService.RecordPayment(id, paymentAmount);

            // Redirect to the invoice details page
            return RedirectToAction("Details", new { id });
        }
    }

}
