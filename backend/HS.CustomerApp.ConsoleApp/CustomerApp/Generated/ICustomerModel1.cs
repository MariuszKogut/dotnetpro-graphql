using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public interface ICustomerModel1
    {
        int Id { get; }

        string Name { get; }

        string Location { get; }
    }
}
