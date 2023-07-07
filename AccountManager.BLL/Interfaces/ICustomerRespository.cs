using AccountManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.BLL.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        List<Customer> GetDebtors();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        void SaveChanges();
    }
}
