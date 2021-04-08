using System.Reflection;
using AutoMapper;
using Xunit;

namespace Chronos.App.UnitTests
{
    public class MappingConfigurationsTests
    {
        [Fact]
        public void WhenProfilesAreConfigured_ItShouldNotThrowException()
        {
            // Arrange
            var config = new MapperConfiguration(configuration =>
            {
                //configuration.EnableEnumMappingValidation();

                configuration.AddMaps(typeof(Startup).GetTypeInfo().Assembly);
            });

            // Assert
            config.AssertConfigurationIsValid();
        }
    }
}
