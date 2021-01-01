using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public interface IGetCustomers
    {
        IReadOnlyList<ICustomerModel> Customers { get; }
    }
}
