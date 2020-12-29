using System;
using System.Threading.Tasks;
using FluentAssertions;
using HotChocolate;
using HotChocolate.Execution;
using HS.CustomerApp.CustomerHost.GraphQlTypes;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;
using Xunit;

namespace HS.CustomerApp.CustomerHost.Tests
{
    public class GraphQlEndpointTests
    {
        [Fact]
        public void ShouldMatchSchema()
        {
            // arrange
            ISchema schema = Schema.Create(c =>
            {
                c.RegisterQueryType<Query>();
            });

            // act
            string schemaSDL = schema.ToString();

            // assert
            schemaSDL.MatchSnapshot();
        }

        [Fact]
        public async Task ShouldResolveDeepQuery()
        {
            // arrange
            IServiceProvider serviceProvider =
                new ServiceCollection()
                    .AddServices()
                    .AddLogging()
                    .BuildServiceProvider();

            IQueryExecutor executor = Schema.Create(c =>
                {
                    c.RegisterQueryType<Query>();
                    c.RegisterType<CustomerModelExtension>();
                    c.RegisterType<PersonModelExtension>();
                })
                .MakeExecutable();

            IReadOnlyQueryRequest request =
                QueryRequestBuilder
                    .New()
                    .SetQuery(@"
                        {
                          customers {
                            id
                            name
                            location
                            employees {
                              id
                              firstname
                              lastname
                              residentialAddress {
                                street
                                streetNo
                                zip
                                city
                                country
                              }
                            }
                          }
                        }
                        ")
                    .SetServices(serviceProvider)
                    .Create();

            // act
            var result = await executor.ExecuteAsync(request);

            // assert
            result.Should().NotBeNull();
            result.Errors.Should().BeEmpty();
            
            var resultAsJson = result.ToJson();
            resultAsJson.MatchSnapshot();
        }
    }
}