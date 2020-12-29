using System.Threading.Tasks;
using FluentAssertions;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;
using Xunit;

namespace HS.CustomerApp.CustomerHost.Tests
{
    public class GraphQlEndpointTests
    {
        [Fact]
        public async Task ShouldMatchSchema()
        {
            // arrange
            ISchema schema =
                await new ServiceCollection()
                    .AddCustomServices()
                    .AddLogging()
                    .AddCustomGraphQl()
                    .BuildSchemaAsync();

            // act
            string result = schema.Print();

            // assert
            result.MatchSnapshot();
        }

        [Fact]
        public async Task ShouldResolveDeepQuery()
        {
            // arrange
            IRequestExecutor executor =
                await new ServiceCollection()
                    .AddCustomServices()
                    .AddLogging()
                    .AddCustomGraphQl()
                    .BuildRequestExecutorAsync();

            // act
            var result = await executor.ExecuteAsync(@"
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
                ");

            // assert
            result.Should().NotBeNull();
            result.Errors.Should().BeNullOrEmpty();

            var resultAsJson = await result.ToJsonAsync();
            resultAsJson.MatchSnapshot();
        }
    }
}