using System.Collections.Generic;
using System.Linq;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public class AddressService : IAddressService
    {
        private readonly List<AddressModel> _data;

        public AddressService(IDataSeeder dataSeeder)
        {
            _data = dataSeeder.Addresses;
        }

        public IQueryable<AddressModel> ReadAll() => _data.AsQueryable();

        public AddressModel Read(long id) => _data.FirstOrDefault(x => x.Id == id);

    }
}