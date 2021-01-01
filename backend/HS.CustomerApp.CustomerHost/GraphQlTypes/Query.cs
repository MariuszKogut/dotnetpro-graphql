using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    public class Query
    {
        [UseFiltering()]
        [UseSorting()]
        public IQueryable<CustomerModel> GetCustomers([Service] ICustomerService service) => service.ReadAll().AsQueryable();
        
        public CustomerModel GetCustomer(int id, [Service] ICustomerService service) =>
            service.Read(id);

        [UseFiltering()]
        [UseSorting()]
        public IQueryable<PersonModel> GetPersons([Service] IPersonService service) => service.ReadAll();
        
        [UseFiltering()]
        [UseSorting()]
        public IQueryable<AddressModel> GetAddresses([Service] IAddressService service) => service.ReadAll();
    }
}