namespace Acme.Net.Microservice.Inventory.gRpc.Test.Core.Mapster;

public class MapsterConfigTest
{
    [Fact]
    public void Configure_ShouldMapProperties_Success()
    {
        // Arrange
        Acme.Net.Microservice.Inventory.gRpc.Core.Mapster.MapsterConfig.Configure();
        var config = TypeAdapterConfig.GlobalSettings;

        // Act
        var mapper = new Mapper(config);

        // Assert
        Assert.NotNull(mapper);
        Assert.NotEmpty(config.RuleMap);
    }
}
