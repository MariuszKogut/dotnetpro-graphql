using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class GetCustomersOperation
        : IOperation<IGetCustomers>
    {
        public string Name => "GetCustomers";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetCustomers);

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            return Array.Empty<VariableValue>();
        }
    }
}
