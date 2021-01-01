using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class CreateCustomerModelInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _intSerializer;
        private IValueSerializer _stringSerializer;

        public string Name { get; } = "CreateCustomerModelInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(CreateCustomerModelInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.GetValueSerializer("Int");
            _stringSerializer = serializerResolver.GetValueSerializer("String");
            _needsInitialization = false;
        }

        public object Serialize(object value)
        {
            if (_needsInitialization)
            {
                throw new InvalidOperationException(
                    $"The serializer for type `{Name}` has not been initialized.");
            }

            if (value is null)
            {
                return null;
            }

            var input = (CreateCustomerModelInput)value;
            var map = new Dictionary<string, object>();

            if (input.EmployeesIds.HasValue)
            {
                map.Add("employeesIds", SerializeNullableListOfInt(input.EmployeesIds.Value));
            }

            if (input.Location.HasValue)
            {
                map.Add("location", SerializeNullableString(input.Location.Value));
            }

            if (input.Name.HasValue)
            {
                map.Add("name", SerializeNullableString(input.Name.Value));
            }

            return map;
        }

        private object SerializeNullableInt(object value)
        {
            return _intSerializer.Serialize(value);
        }

        private object SerializeNullableListOfInt(object value)
        {
            if (value is null)
            {
                return null;
            }


            IList source = (IList)value;
            object[] result = new object[source.Count];
            for(int i = 0; i < source.Count; i++)
            {
                result[i] = SerializeNullableInt(source[i]);
            }
            return result;
        }
        private object SerializeNullableString(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _stringSerializer.Serialize(value);
        }

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
