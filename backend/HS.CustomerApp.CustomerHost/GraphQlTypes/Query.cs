using System.Collections.Generic;
using HotChocolate;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    public class Query
    {
        public IEnumerable<CustomerModel> GetCustomers([Service] ICustomerService service) => service.ReadAll();
        public IEnumerable<PersonModel> GetPersons([Service] IPersonService service) => service.ReadAll();
        public IEnumerable<AddressModel> GetAddresses([Service] IAddressService service) => service.ReadAll();
    }
}