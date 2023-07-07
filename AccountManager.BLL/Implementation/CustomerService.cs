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
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer CreateCustomer(string name, string email, string phone, string address)
        {
            var customer = new Customer
            {
                Name = name,
                Email = email,
                PhoneNumber = phone,
                Address = address
            };

            _customerRepository.Add(customer);
            _customerRepository.SaveChanges();

            return customer;
        }

        public void UpdateCustomer(int id, string name, string email, string phone, string address)
        {
            var customer = _customerRepository.GetById(id);

            if (customer != null)
            {
                customer.Name = name;
                customer.Email = email;
                customer.PhoneNumber = phone;
                customer.Address = address;

                _customerRepository.Update(customer);
                _customerRepository.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer != null)
            {
                _customerRepository.Delete(customer);
                _customerRepository.SaveChanges();
            }
        }
    }


}
