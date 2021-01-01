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
    public class CreateCustomerResultParser
        : JsonResultParserBase<ICreateCustomer>
    {
        private readonly IValueSerializer _intSerializer;

        public CreateCustomerResultParser(IValueSerializerResolver serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.GetValueSerializer("Int");
        }

        protected override ICreateCustomer ParserData(JsonElement data)
        {
            return new CreateCustomer1
            (
                DeserializeInt(data, "createCustomer")
            );

        }

        private int DeserializeInt(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (int)_intSerializer.Deserialize(value.GetInt32());
        }
    }
}
