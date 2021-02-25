using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace BusinessLogic.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        List<Customer> GetCustomerByName(string searchingKey);
        List<Customer> SortCustomersByName();
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
