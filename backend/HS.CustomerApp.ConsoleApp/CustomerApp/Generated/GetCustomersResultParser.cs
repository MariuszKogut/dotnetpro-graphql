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
    public class GetCustomersResultParser
        : JsonResultParserBase<IGetCustomers>
    {
        private readonly IValueSerializer _intSerializer;
        private readonly IValueSerializer _stringSerializer;

        public GetCustomersResultParser(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.GetValueSerializer("Int");
            _stringSerializer = serializerResolver.GetValueSerializer("String");
        }

        protected override IGetCustomers ParserData(JsonElement data)
        {
            return new GetCustomers
            (
                ParseGetCustomersCustomers(data, "customers")
            );

        }

        private IReadOnlyList<ICustomerModel> ParseGetCustomersCustomers(
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

            int objLength = obj.GetArrayLength();
            var list = new ICustomerModel[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new CustomerModel
                (
                    DeserializeInt(element, "id"),
                    DeserializeNullableString(element, "name"),
                    DeserializeNullableString(element, "location")
                );

            }

            return list;
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
