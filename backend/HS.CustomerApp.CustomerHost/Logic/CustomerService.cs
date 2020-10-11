using System.Collections.Generic;
using System.Linq;
using Bogus;
using HS.CustomerApp.CustomerHost.Models;
using Microsoft.Extensions.Logging;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;

        private List<CustomerModel> _data = new List<CustomerModel>();

        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
            SeedSampleData();
        }

        public long Create(CustomerModel customerModel)
        {
            var id = _data.Any() ? _data.Max(x => x.Id) + 1 : 1;
            customerModel.Id = id;
            _data.Add(customerModel);
            return id;
        }

        public IEnumerable<CustomerModel> ReadAll() => _data;

        public CustomerModel Read(long id) => _data.FirstOrDefault(x => x.Id == id);

        public void Update(CustomerModel customerModel) =>
            _data[_data.FindIndex(x => x.Id == customerModel.Id)] = customerModel;

        public void Delete(long id)
        {
            _logger.LogInformation("Delete customer with id {id}", id);
            _data.RemoveAll(x => x.Id == id);
        }

        private void SeedSampleData()
        {
            var customerId = 0;

            _data = new Faker<CustomerModel>()
                .RuleFor(x => x.Id, (f, u) => customerId++)
                .RuleFor(x => x.Name, (f, u) => f.Company.CompanyName())
                .RuleFor(x => x.Location, (f, u) => f.Address.Country())
                .Generate(100);
        }
    }
}