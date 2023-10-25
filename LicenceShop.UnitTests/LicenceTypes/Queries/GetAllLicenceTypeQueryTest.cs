using FluentAssertions;
using FluentAssertions.Execution;
using LicenceShop.Application.Licence.Queries;
using LicenceShop.Application.LicenceType.Queries;
using LicenceShop.BaseTests;
using LicenceShop.BaseTests.Builders.Queries;
using LicenceShop.BaseTests.Builders.Queries.LicenceTypes;
using LicenceShop.BaseTests.Data;
using MongoDB.Entities;
using Xunit;

namespace LicenceShop.UnitTests.LicenceTypes.Queries;

public class GetAllLicenceTypeQueryTest : Base
{
    [Fact]
    public async Task GetLicenceTypePageableQuery_Filters_ReturnLicenceTypePageableList()
    {
        
        //Given(Arrange)= what is part of request
        var licenceType = new LicenceTypeBuilder().Build();
        await licenceType.SaveAsync();
        
        //When (Act) - what we do with that data

        var handler = new GetLicenceTypePageableQueryHandler(Mapper);
        var query = new GetLicenceTypePageableQueryBuilder().Build();
        var response = await handler.Handle(query, new CancellationToken());
        
        
        //Then (Assert) - what is response

        using var _ = new AssertionScope();
        response.Should().NotBeNull();
        response.Types.Should().NotBeNull();
        response.Types.Should().HaveCount(1);

        await DB.Database("LicenceShopTests").Client.DropDatabaseAsync("LicenceShopTests");


    }
}