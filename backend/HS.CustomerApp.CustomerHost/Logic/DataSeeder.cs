using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public class DataSeeder : IDataSeeder
    {
        public List<CustomerModel> Customers { get; }
        public List<PersonModel> Persons { get; }
        public List<AddressModel> Addresses { get; }

        public DataSeeder()
        {
            var addressId = 0;

            Randomizer.Seed = new Random(8675309);
            
            Addresses = new Faker<AddressModel>()
                .RuleFor(x => x.Id, (f) => addressId++)
                .RuleFor(x => x.Street, (f) => f.Address.StreetName())
                .RuleFor(x => x.StreetNo, (f) => f.Address.BuildingNumber())
                .RuleFor(x => x.Zip, (f) => f.Address.ZipCode())
                .RuleFor(x => x.City, (f) => f.Address.City())
                .RuleFor(x => x.Country, (f) => f.Address.Country())
                .Generate(250);

            var personId = 1;

            Persons = new Faker<PersonModel>()
                .RuleFor(x => x.Id, (f, u) => personId++)
                .RuleFor(x => x.Firstname, (f, u) => f.Name.FirstName())
                .RuleFor(x => x.Lastname, (f, u) => f.Name.LastName())
                .RuleFor(x => x.ResidentialAddressId, (f, u) => f.Random.Int(1, 250))
                .Generate(500);

            var customerId = 1;

            Customers = new Faker<CustomerModel>()
                .RuleFor(x => x.Id, (f, u) => customerId++)
                .RuleFor(x => x.Name, (f, u) => f.Company.CompanyName())
                .RuleFor(x => x.Location, (f, u) => f.Address.Country())
                .RuleFor(x => x.EmployeesIds, (f, u) =>
                    Enumerable.Range(1, f.Random.Int(1, 25)).Select(y => y)
                )
                .Generate(100);
        }
    }
}