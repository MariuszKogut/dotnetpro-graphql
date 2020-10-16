using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    [ExtendObjectType(Name = nameof(PersonModel))]
    public class PersonModelExtension
    {
        public AddressModel
            GetResidentialAddress([Service] IAddressService service, IResolverContext context) =>
            service.Read(context.Parent<PersonModel>().ResidentialAddressId);
    }
}