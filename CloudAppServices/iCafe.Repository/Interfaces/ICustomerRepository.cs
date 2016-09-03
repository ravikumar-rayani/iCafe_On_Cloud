using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;
using iCafe.Data.Infrastructure;

namespace iCafe.Repository.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
        Customer GetCustomerByName(string CustomerName);
    }
}
