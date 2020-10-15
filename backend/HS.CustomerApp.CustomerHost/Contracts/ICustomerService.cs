using System.Collections.Generic;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Contracts
{
    public interface ICustomerService
    {
        int Create(CustomerModel customerModel);
        IEnumerable<CustomerModel> ReadAll();
        CustomerModel Read(long id);
        void Update(CustomerModel customerModel);
        void Delete(long id);
    }
}