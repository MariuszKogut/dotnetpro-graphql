using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public interface ICustomerAppClient
    {
        Task<IOperationResult<IGetCustomers>> GetCustomersAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IGetCustomers>> GetCustomersAsync(
            GetCustomersOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IGetCustomer>> GetCustomerAsync(
            Optional<int> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IGetCustomer>> GetCustomerAsync(
            GetCustomerOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<ICreateCustomer>> CreateCustomerAsync(
            Optional<CreateCustomerModelInput> customer = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<ICreateCustomer>> CreateCustomerAsync(
            CreateCustomerOperation operation,
            CancellationToken cancellationToken = default);
    }
}
