using FluentAssertions;
using FluentAssertions.Execution;
using LicenceShop.Application.Car.Queries;
using LicenceShop.Application.Category.Queries;
using LicenceShop.Application.Vendor.Queries;
using LicenceShop.BaseTests;
using LicenceShop.BaseTests.Builders.Queries;
using LicenceShop.BaseTests.Builders.Queries.Categories;
using LicenceShop.BaseTests.Data;
using MongoDB.Entities;
using Xunit;

namespace LicenceShop.UnitTests.Categories.Queries;

public class GetAllCategoryQueryTests : Base
{
    [Fact]
    public async Task GetCategoryPageableQuery_Filters_ReturnCategoryPageableList()
    {
        
        //Given(Arrange)= what is part of request
        var category = new CategoryBuilder().Build();
        await category.SaveAsync();
        
        //When (Act) - what we do with that data

        var handler = new GetPageableCategoryQueryHandler(Mapper);
        var query = new GetCategoryPageableQueryBuilder().Build();
        var response = await handler.Handle(query, new CancellationToken());
        
        
        //Then (Assert) - what is response

        using var _ = new AssertionScope();
        response.Should().NotBeNull();
        response.Categories.Should().NotBeNull();
        response.Categories.Should().HaveCount(1);

        await DB.Database("LicenceShopTests").Client.DropDatabaseAsync("LicenceShopTests");


    }
}