using AutoMapper;
using LicenceShop.Application.Vendor.Commands;
using LicenceShop.BaseTests.Builders.Commands;
using LicenceShop.BaseTests.Builders.Commands.Vendors;
using LicenceShop.BaseTests.Data;
using MongoDB.Entities;
using Xunit;

namespace LicenceShop.UnitTests.Vendors.Commands;

public class CreateVendorCommandTests
{
    
    [Fact]
    public Task CreateVendorCommand_CreateVendorDto_ReturnVendorDto()
    {
        const string expectedName = "Microsoft";
        const bool expectedActive = true;
        var builder = new CreateVendorCommandBuilder();

        // Act
        var createVendorCommand = builder.Build();

        // Assert
        Assert.NotNull(createVendorCommand);
        Assert.Equal(expectedName, createVendorCommand.Vendor.Name);
        Assert.Equal(expectedActive, createVendorCommand.Vendor.Active);
        return Task.CompletedTask;
    }
}