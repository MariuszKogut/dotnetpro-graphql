using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class GetCustomers
        : IGetCustomers
    {
        public GetCustomers(
            IReadOnlyList<ICustomerModel> customers)
        {
            Customers = customers;
        }

        public IReadOnlyList<ICustomerModel> Customers { get; }
    }
}
