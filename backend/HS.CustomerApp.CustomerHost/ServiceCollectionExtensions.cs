using FluentValidation;
using HotChocolate.Execution.Configuration;
using HS.CustomerApp.CustomerHost.Contracts;
using HS.CustomerApp.CustomerHost.GraphQlTypes;
using HS.CustomerApp.CustomerHost.Logic;
using HS.CustomerApp.CustomerHost.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HS.CustomerApp.CustomerHost
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services) =>
            services
                .AddSingleton<ICustomerService, CustomerService>()
                .AddSingleton<IPersonService, PersonService>()
                .AddSingleton<IAddressService, AddressService>()
                .AddSingleton<IDataSeeder, DataSeeder>()
                .AddTransient<IValidator<CustomerModel>, CustomerValidator>();

        public static IRequestExecutorBuilder AddCustomGraphQl(this IServiceCollection services) =>
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<CustomerModelExtension>()
                .AddType<PersonModelExtension>();
    }
}