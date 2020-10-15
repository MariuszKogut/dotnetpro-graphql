using HotChocolate.Types;
using HS.CustomerApp.CustomerHost.Contracts;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.Customers).Resolver(x => x.Service<ICustomerService>().ReadAll());
            descriptor.Field(x => x.Persons).Resolver(x => x.Service<IPersonService>().ReadAll());
            descriptor.Field(x => x.Address).Resolver(x => x.Service<IAddressService>().ReadAll());
        }
    }
}