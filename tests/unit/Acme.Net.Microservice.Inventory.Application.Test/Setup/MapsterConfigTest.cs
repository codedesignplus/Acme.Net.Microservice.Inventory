using Acme.Net.Microservice.Inventory.Application.Setup;

namespace Acme.Net.Microservice.Inventory.Application.Test.Setup;

public class MapsterConfigTest
{
    [Fact]
    public void Configure_ShouldMapProperties_Success()
    {
        // Arrange
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(MapsterConfigInventory).Assembly);

        // Act
        var mapper = new Mapper(config);

        // Assert
        Assert.NotNull(mapper);
    }
}
