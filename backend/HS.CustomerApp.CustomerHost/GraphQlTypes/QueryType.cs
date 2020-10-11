using System.Collections.Generic;
using HotChocolate;
using HS.CustomerApp.CustomerHost.Logic;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    public class QueryType
    {
        public IEnumerable<CustomerModel> GetCustomers([Service] ICustomerService customerService) =>
            customerService.ReadAll();
    }
}