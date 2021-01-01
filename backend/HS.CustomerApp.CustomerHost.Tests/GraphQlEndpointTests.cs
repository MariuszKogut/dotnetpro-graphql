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
        public async Task ShouldResolveDeepCustomerQuery()
        {
            // arrange
            var executor = await GetRequestExecutor();

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

        [Fact]
        public async Task ShouldResolveCustomerByIdQuery()
        {
            // arrange
            var executor = await GetRequestExecutor();

            // act
            var result = await executor.ExecuteAsync(@"
               {
                  customer(id: 1) {
                    name,
                    location,
                  }
                }
                ");

            // assert
            result.Should().NotBeNull();
            result.Errors.Should().BeNullOrEmpty();

            var resultAsJson = await result.ToJsonAsync();
            resultAsJson.MatchSnapshot();
        }

        [Fact]
        public async Task ShouldApplyFilterCorrectly()
        {
            // arrange
            var executor = await GetRequestExecutor();

            // act
            var result = await executor.ExecuteAsync(@"
                {
                  customers(
                    where: {
                      or: [ 
                            {location: { eq: ""Ireland"" } }
                            {location: { startsWith: ""B"" } }
                          ] 
                        }
                     order: {name: DESC}
                    ) {
                     name
                     location
                    }
                }
                ");

            // assert
            result.Should().NotBeNull();
            result.Errors.Should().BeNullOrEmpty();

            var resultAsJson = await result.ToJsonAsync();
            resultAsJson.MatchSnapshot();
        }

        [Fact]
        public async void ShouldCreateCustomer()
        {
            // arrange
            var executor = await GetRequestExecutor();

            // act
            var result = await executor.ExecuteAsync(@"
                mutation CreateCustomer {
                  createCustomer(
                    input: {
                      location: ""Germany"",
                       name: ""Handmade Systems""
                     }
                  )
                }                
                ");

            // assert
            result.Should().NotBeNull();
            result.Errors.Should().BeNullOrEmpty();

            var resultAsJson = await result.ToJsonAsync();
            resultAsJson.MatchSnapshot();
        }

        private static async Task<IRequestExecutor> GetRequestExecutor() =>
            await new ServiceCollection()
                .AddCustomServices()
                .AddLogging()
                .AddCustomGraphQl()
                .BuildRequestExecutorAsync();
    }
}