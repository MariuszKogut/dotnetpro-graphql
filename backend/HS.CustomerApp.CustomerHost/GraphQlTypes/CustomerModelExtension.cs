using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    [ExtendObjectType(Name = nameof(CustomerModel))]
    public class CustomerModelExtension
    {
        [UseFiltering()]
        [UseSorting()]
        public IQueryable<PersonModel> GetEmployees([Service] IPersonService service, CustomerModel customerModel) =>
            service.ReadByIds(customerModel.EmployeesIds);
    }
}