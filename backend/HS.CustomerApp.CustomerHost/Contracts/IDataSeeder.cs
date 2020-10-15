using System.Collections.Generic;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Contracts
{
    public interface IDataSeeder
    {
        List<CustomerModel> Customers { get; }
        List<PersonModel> Persons { get; }
        List<AddressModel> Addresses { get; }
    }
}