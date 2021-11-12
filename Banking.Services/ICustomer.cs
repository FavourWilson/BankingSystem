using Banking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public interface ICustomer
    {
        IEnumerable<Customer_Details> GetCustomers();
        Customer_Details Add(Customer_Details Details);
        Customer_Details Update(int id, Customer_Details customer);
        Customer_Details GetCustomer(int id);
        Customer_Details Delete(int id);
    }
}
