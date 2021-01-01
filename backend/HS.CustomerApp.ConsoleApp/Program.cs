using System;
using System.Linq;
using HS.CustomerApp.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;
using static System.Console;

WriteLine("Init...");
var serviceCollection = new ServiceCollection();
serviceCollection.AddHttpClient("CustomerAppClient", c => c.BaseAddress = new Uri("https://localhost:5001/graphql"));
serviceCollection.AddCustomerAppClient();

var serviceProvider = serviceCollection.BuildServiceProvider();
var client = serviceProvider.GetService<ICustomerAppClient>();

WriteLine("Get all customer...");
var customers = await client.GetCustomersAsync();
customers.Data?.Customers
    .ToList()
    .ForEach(x => WriteLine($"{x.Id} - {x.Name} - {x.Location}"));

WriteLine("Get customer by id...");
var customer = await client.GetCustomerAsync(new Optional<int>(1));
WriteLine($"{customer.Data?.Customer.Id} - {customer.Data?.Customer.Name} - {customer.Data?.Customer.Location}");
    
WriteLine("Create new customer...");
await client.CreateCustomerAsync(new Optional<CreateCustomerModelInput>(new CreateCustomerModelInput
{
    Name = "Handmade Systems",
    Location = "Germany"
}));

WriteLine("Over and out!");