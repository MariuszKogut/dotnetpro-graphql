using HotChocolate.Types;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    public class PersonType : ObjectType<PersonModel>
    {
        protected override void Configure(IObjectTypeDescriptor<PersonModel> descriptor)
        {
            descriptor.Field(x => x.ResidentialAddressId)
                .Name("residentialAddress")
                .Type<AddressModelType>()
                .Resolver(x => x.Service<IAddressService>().Read(x.Parent<PersonModel>().ResidentialAddressId));
        }
    }
}