using HotChocolate;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    public class Mutation
    {
        public int CreateCustomer(CreateCustomerModel input, [Service] ICustomerService service) =>
            service.Create(new CustomerModel
            {
                Location = input.Location,
                Name = input.Name,
                EmployeesIds = input.EmployeesIds
            });

        public CustomerModel UpdateCustomerLocation(long id, string location, [Service] ICustomerService service)
        {
            var customer = service.Read(id);

            customer.Location = location;
            service.Update(customer);

            return customer;
        }
    }
}