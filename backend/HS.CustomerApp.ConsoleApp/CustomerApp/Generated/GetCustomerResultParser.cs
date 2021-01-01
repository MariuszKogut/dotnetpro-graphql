using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace HS.CustomerApp.ConsoleApp
{
    public class GetCustomerResultParser
        : JsonResultParserBase<IGetCustomer>
    {
        private readonly IValueSerializer _intSerializer;
        private readonly IValueSerializer _stringSerializer;

        public GetCustomerResultParser(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.GetValueSerializer("Int");
            _stringSerializer = serializerResolver.GetValueSerializer("String");
        }

        protected override IGetCustomer ParserData(JsonElement data)
        {
            return new GetCustomer
            (
                ParseGetCustomerCustomer(data, "customer")
            );

        }

        private ICustomerModel1 ParseGetCustomerCustomer(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new CustomerModel1
            (
                DeserializeInt(obj, "id"),
                DeserializeNullableString(obj, "name"),
                DeserializeNullableString(obj, "location")
            );
        }

        private int DeserializeInt(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (int)_intSerializer.Deserialize(value.GetInt32());
        }

        private string DeserializeNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string)_stringSerializer.Deserialize(value.GetString());
        }
    }
}
