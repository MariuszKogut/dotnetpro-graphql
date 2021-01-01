using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class CustomerModel1
        : ICustomerModel1
    {
        public CustomerModel1(
            int id, 
            string name, 
            string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        public int Id { get; }

        public string Name { get; }

        public string Location { get; }
    }
}
