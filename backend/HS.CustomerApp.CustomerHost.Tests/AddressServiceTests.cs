using System.Linq;
using FluentAssertions;
using HS.CustomerApp.CustomerHost.Logic;
using Xunit;

namespace HS.CustomerApp.CustomerHost.Tests
{
    public class AddressServiceTest
    {
        [Fact]
        public void ShouldReturnSingleAddress()
        {
            // Arrange
            var sut = new AddressService(new DataSeeder());
            
            // Act
            var result = sut.Read(1);

            // Assert
            result.Should().NotBeNull();
            result.Street.Should().NotBeNullOrEmpty();
            result.StreetNo.Should().NotBeNullOrEmpty();
            result.Zip.Should().NotBeNullOrEmpty();
            result.City.Should().NotBeNullOrEmpty();
            result.Country.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ShouldReturnManyAddresss()
        {
            // Arrange
            var sut = new AddressService(new DataSeeder());
            
            // Act
            var result = sut.ReadAll();

            // Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(250);
        }
    }
}