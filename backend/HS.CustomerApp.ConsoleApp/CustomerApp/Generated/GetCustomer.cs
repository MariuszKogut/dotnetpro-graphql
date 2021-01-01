using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class GetCustomer
        : IGetCustomer
    {
        public GetCustomer(
            ICustomerModel1 customer)
        {
            Customer = customer;
        }

        public ICustomerModel1 Customer { get; }
    }
}
