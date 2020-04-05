using System.Collections.Generic;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public interface ICustomerService
    {
        long Create(CustomerModel customerModel);
        IEnumerable<CustomerModel> ReadAll();
        CustomerModel Read(long id);
        void Update(CustomerModel customerModel);
        void Delete(long id);
    }
}