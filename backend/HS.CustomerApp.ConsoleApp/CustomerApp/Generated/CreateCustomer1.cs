using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class CreateCustomer1
        : ICreateCustomer
    {
        public CreateCustomer1(
            int createCustomer)
        {
            CreateCustomer = createCustomer;
        }

        public int CreateCustomer { get; }
    }
}
