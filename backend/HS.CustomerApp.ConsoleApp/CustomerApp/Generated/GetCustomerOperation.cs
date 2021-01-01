using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class GetCustomerOperation
        : IOperation<IGetCustomer>
    {
        public string Name => "GetCustomer";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetCustomer);

        public Optional<int> Id { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Id.HasValue)
            {
                variables.Add(new VariableValue("id", "Int", Id.Value));
            }

            return variables;
        }
    }
}
