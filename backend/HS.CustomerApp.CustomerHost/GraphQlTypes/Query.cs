using System.Collections.Generic;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.GraphQlTypes
{
    public class Query
    {
        public IEnumerable<CustomerModel> Customers { get; set; }
        public IEnumerable<PersonModel> Persons { get; set; }
        public IEnumerable<AddressModel> Address { get; set; }
    }
}