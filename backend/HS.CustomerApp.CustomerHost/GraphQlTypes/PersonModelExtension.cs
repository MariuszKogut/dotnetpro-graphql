using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    [ExtendObjectType(Name = nameof(PersonModel))]
    public class PersonModelExtension
    {
        [UseFiltering()]
        [UseSorting()]
        public AddressModel
            GetResidentialAddress([Service] IAddressService service, PersonModel personModel) =>
            service.Read(personModel.ResidentialAddressId);
    }
}