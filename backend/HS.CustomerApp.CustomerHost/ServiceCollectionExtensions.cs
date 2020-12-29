using FluentValidation;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.Logic;
using HS.CustomerApp.CustomerHost.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HS.CustomerApp.CustomerHost
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IAddressService, AddressService>();
            services.AddSingleton<IDataSeeder, DataSeeder>();
            services.AddTransient<IValidator<CustomerModel>, CustomerValidator>();

            return services;
        }
    }
}