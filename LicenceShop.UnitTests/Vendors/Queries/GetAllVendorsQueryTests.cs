using MongoDB.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using LicenceShop.Application.Vendor.Queries;
using LicenceShop.BaseTests;
using LicenceShop.BaseTests.Builders.Queries;
using LicenceShop.BaseTests.Builders.Queries.Vendors;
using LicenceShop.BaseTests.Data;
using Xunit;

namespace LicenceShop.UnitTests.Vendors.Queries;

public class GetAllVendorsQueryTests : Base
{
    [Fact]
    public async Task GetVendorsPageableQuery_Filters_ReturnVendorsPageableList()
    {
        
        //Given(Arrange)= what is part of request
        var vendor = new VendorBuilder().Build();
        await vendor.SaveAsync();
        
        //When (Act) - what we do with that data

        var handler = new GetAllVendorsPageableQueryHandler(Mapper);
        var query = new GetVendorsPageableQueryBuilder().Build();
        var response = await handler.Handle(query, new CancellationToken());
        
        
        //Then (Assert) - what is response

        using var _ = new AssertionScope();
        response.Should().NotBeNull();
        response.Vendors.Should().NotBeNull();
        response.Vendors.Should().HaveCount(1);

        await DB.Database("LicenceShopTests").Client.DropDatabaseAsync("LicenceShopTests");


    }
}