using AccountManager.BLL.Interfaces;
using AccountManager.DAL.Data;
using AccountManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.BLL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer GetById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> GetDebtors()
        {
            return _dbContext.Customers
                       .Where(c => c.Invoices.Any(i => i.PaidAmount < i.TotalAmount))
                       .ToList();
        }

        public void Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _dbContext.Customers.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
