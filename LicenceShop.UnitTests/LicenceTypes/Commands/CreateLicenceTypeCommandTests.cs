using LicenceShop.Application.LicenceType.Commands;
using LicenceShop.BaseTests.Builders.Commands.LicenceType;
using Xunit;

namespace LicenceShop.UnitTests.LicenceTypes.Commands;

public class CreateLicenceTypeCommandTests
{
    [Fact]
    public Task CreateLicenceTypeCommand_CreateLicenceTypeDto_ReturnLicenceTypeDto()
    {
        const string expectedName = "Premium";
        const bool expectedActive = true;
        var builder = new CreateLicenceTypeCommandBuilder();

        // Act
        var createVendorCommand = builder.Build();

        // Assert
        Assert.NotNull(createVendorCommand);
        Assert.Equal(expectedName, createVendorCommand.LicenceType.Name);
        Assert.Equal(expectedActive, createVendorCommand.LicenceType.Active);
        return Task.CompletedTask;
    }
}