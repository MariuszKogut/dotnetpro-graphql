using HotChocolate.Types;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    public class CustomerType : ObjectType<CustomerModel>
    {
        protected override void Configure(IObjectTypeDescriptor<CustomerModel> descriptor)
        {
            descriptor
                .Field("employees")
                .Type<ListType<PersonType>>()
                .Resolver(x =>  x.Service<IPersonService>().ReadByIds(x.Parent<CustomerModel>().EmployeesIds));
        }
    }
}