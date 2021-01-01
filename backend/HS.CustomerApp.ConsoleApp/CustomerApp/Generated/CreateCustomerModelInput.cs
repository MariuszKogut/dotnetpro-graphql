using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class CreateCustomerModelInput
    {
        public Optional<IReadOnlyList<int>> EmployeesIds { get; set; }

        public Optional<string> Location { get; set; }

        public Optional<string> Name { get; set; }
    }
}
