using AccountManager.BLL.Implementation;
using Accounts_Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Accounts_Manager.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Create()
        {
            // Return the view for creating a new customer
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create the customer
                var customer = _customerService.CreateCustomer(model.Name, model.Email, model.Phone, model.Address);

                // Redirect to the customer details page
                return RedirectToAction("Details", new { id = customer.Id });
            }

            // If the model is invalid, return the view with validation errors
            return View(model);
        }

        public IActionResult Details(int id)
        {
            // Retrieve the customer by id
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                // Return a not found view or redirect to an error page
                return NotFound();
            }

            // Return the view with the customer details
            return View(customer);
        }

        public IActionResult Update(int id)
        {
            // Retrieve the customer by id
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                // Return a not found view or redirect to an error page
                return NotFound();
            }

            // Map the customer data to the view model
            var model = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.PhoneNumber,
                Address = customer.Address
            };

            // Return the view for updating the customer
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Update the customer
                _customerService.UpdateCustomer(model.Id, model.Name, model.Email, model.Phone, model.Address);

                // Redirect to the customer details page
                return RedirectToAction("Details", new { id = model.Id });
            }

            // If the model is invalid, return the view with validation errors
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            // Delete the customer
            _customerService.DeleteCustomer(id);

            // Redirect to the customer listing page or home page
            return RedirectToAction("Index", "Home");
        }
    }

}
