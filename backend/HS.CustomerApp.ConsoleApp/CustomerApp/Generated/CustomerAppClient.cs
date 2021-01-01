using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class CustomerAppClient
        : ICustomerAppClient
    {
        private const string _clientName = "CustomerAppClient";

        private readonly IOperationExecutor _executor;

        public CustomerAppClient(IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public Task<IOperationResult<IGetCustomers>> GetCustomersAsync(
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetCustomersOperation(),
                cancellationToken);
        }

        public Task<IOperationResult<IGetCustomers>> GetCustomersAsync(
            GetCustomersOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<IGetCustomer>> GetCustomerAsync(
            Optional<int> id = default,
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetCustomerOperation { Id = id },
                cancellationToken);
        }

        public Task<IOperationResult<IGetCustomer>> GetCustomerAsync(
            GetCustomerOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<ICreateCustomer>> CreateCustomerAsync(
            Optional<CreateCustomerModelInput> customer = default,
            CancellationToken cancellationToken = default)
        {
            if (customer.HasValue && customer.Value is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            return _executor.ExecuteAsync(
                new CreateCustomerOperation { Customer = customer },
                cancellationToken);
        }

        public Task<IOperationResult<ICreateCustomer>> CreateCustomerAsync(
            CreateCustomerOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
