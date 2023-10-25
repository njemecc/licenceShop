using LicenceShop.Application.Category.Commands;
using LicenceShop.BaseTests.Builders.Commands;
using Xunit;

namespace LicenceShop.UnitTests.Categories.Commands;

public class CreateCategoryCommandTests
{
    [Fact]
    public Task CreateCategoryCommand_CreateCategoryDto_ReturnCreateCategoryDto()
    {
        const string expectedName = "Cyber-sec";
        const bool expectedActive = true;
        var builder = new CreateCategoryCommandBuilder();

        // Act
        var createCategoryCommand = builder.Build();

        // Assert
        Assert.NotNull(createCategoryCommand);
        Assert.Equal(expectedName, createCategoryCommand.Category.Name);
        Assert.Equal(expectedActive, createCategoryCommand.Category.Active);
        return Task.CompletedTask;
    }
}