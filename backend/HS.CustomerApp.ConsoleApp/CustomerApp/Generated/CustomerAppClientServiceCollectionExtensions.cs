using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StrawberryShake;
using StrawberryShake.Http;
using StrawberryShake.Http.Pipelines;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Serializers;
using StrawberryShake.Transport;

namespace HS.CustomerApp.ConsoleApp
{
    public static class CustomerAppClientServiceCollectionExtensions
    {
        private const string _clientName = "CustomerAppClient";

        public static IServiceCollection AddCustomerAppClient(
            this IServiceCollection serviceCollection)
        {
            if (serviceCollection is null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddSingleton<ICustomerAppClient, CustomerAppClient>();
            serviceCollection.AddSingleton<IOperationExecutorFactory>(sp =>
                new HttpOperationExecutorFactory(
                    _clientName,
                    sp.GetRequiredService<IHttpClientFactory>().CreateClient,
                    PipelineFactory(sp),
                    sp));

            serviceCollection.TryAddSingleton<IOperationExecutorPool, OperationExecutorPool>();

            serviceCollection.AddDefaultScalarSerializers();
            serviceCollection.AddInputSerializers();
            serviceCollection.AddResultParsers();

            serviceCollection.TryAddDefaultOperationSerializer();
            serviceCollection.TryAddDefaultHttpPipeline();

            return serviceCollection;
        }

        private static IServiceCollection AddDefaultScalarSerializers(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IValueSerializerResolver, ValueSerializerResolver>();

            foreach (IValueSerializer serializer in ValueSerializers.All)
            {
                serviceCollection.AddSingleton(serializer);
            }

            return serviceCollection;
        }


        private static IServiceCollection AddInputSerializers(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IValueSerializer, CreateCustomerModelInputSerializer>();
            return serviceCollection;
        }

        private static IServiceCollection AddResultParsers(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IResultParserResolver, ResultParserResolver>();
            serviceCollection.AddSingleton<IResultParser, GetCustomersResultParser>();
            serviceCollection.AddSingleton<IResultParser, GetCustomerResultParser>();
            serviceCollection.AddSingleton<IResultParser, CreateCustomerResultParser>();
            return serviceCollection;
        }

        private static IServiceCollection TryAddDefaultOperationSerializer(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IOperationFormatter, JsonOperationFormatter>();
            return serviceCollection;
        }

        private static IServiceCollection TryAddDefaultHttpPipeline(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<OperationDelegate>(
                sp => HttpPipelineBuilder.New()
                    .Use<CreateStandardRequestMiddleware>()
                    .Use<SendHttpRequestMiddleware>()
                    .Use<ParseSingleResultMiddleware>()
                    .Build(sp));
            return serviceCollection;
        }

        private static OperationDelegate PipelineFactory(IServiceProvider services)
        {
            return services.GetRequiredService<OperationDelegate>();
        }
    }
}
