using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class CreateCustomerOperation
        : IOperation<ICreateCustomer>
    {
        public string Name => "CreateCustomer";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(ICreateCustomer);

        public Optional<CreateCustomerModelInput> Customer { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Customer.HasValue)
            {
                variables.Add(new VariableValue("customer", "CreateCustomerModelInput", Customer.Value));
            }

            return variables;
        }
    }
}
