using System.Linq;
using FluentAssertions;
using HS.CustomerApp.CustomerHost.Logic;
using Xunit;

namespace HS.CustomerApp.CustomerHost.Tests
{
    public class PersonServiceTest
    {
        [Fact]
        public void ShouldReturnSinglePerson()
        {
            // Arrange
            var sut = new PersonService();
            
            // Act
            var result = sut.Read(1);

            // Assert
            result.Should().NotBeNull();
            result.Firstname.Should().NotBeNullOrEmpty();
            result.Lastname.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ShouldReturnManyPersons()
        {
            // Arrange
            var sut = new PersonService();
            
            // Act
            var result = sut.ReadAll();

            // Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(500);
        }
    }
}