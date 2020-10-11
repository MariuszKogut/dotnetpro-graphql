using System.Collections.Generic;
using System.Linq;
using Bogus;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public class AddressService : IAddressService
    {
        private List<AddressModel> _data = new List<AddressModel>();

        public AddressService()
        {
            SeedSampleData();
        }

        public IEnumerable<AddressModel> ReadAll() => _data;

        public AddressModel Read(long id) => _data.FirstOrDefault(x => x.Id == id);

        private void SeedSampleData()
        {
            var id = 0;

            _data = new Faker<AddressModel>()
                .RuleFor(x => x.Id, (f) => id++)
                .RuleFor(x => x.Street, (f) => f.Address.StreetName())
                .RuleFor(x => x.StreetNo, (f) => f.Address.BuildingNumber())
                .RuleFor(x => x.Zip, (f) => f.Address.ZipCode())
                .RuleFor(x => x.City, (f) => f.Address.City())
                .RuleFor(x => x.Country, (f) => f.Address.Country())
                .Generate(250);
        }
    }
}