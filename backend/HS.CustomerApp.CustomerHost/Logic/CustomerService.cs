using System.Collections.Generic;
using System.Linq;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Models;
using Microsoft.Extensions.Logging;

namespace HS.CustomerApp.CustomerHost.Logic
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;

        private readonly List<CustomerModel> _data;

        public CustomerService(IDataSeeder dataSeeder, ILogger<CustomerService> logger)
        {
            _logger = logger;
            _data = dataSeeder.Customers;
        }

        public int Create(CustomerModel customerModel)
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
    }
}