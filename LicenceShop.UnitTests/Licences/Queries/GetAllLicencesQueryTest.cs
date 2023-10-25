using FluentAssertions;
using FluentAssertions.Execution;
using LicenceShop.Application.Licence.Queries;
using LicenceShop.BaseTests;
using LicenceShop.BaseTests.Builders.Queries;
using LicenceShop.BaseTests.Builders.Queries.Licences;
using LicenceShop.BaseTests.Data;
using MongoDB.Entities;
using Xunit;

namespace LicenceShop.UnitTests.Licences.Queries;

public class GetAllLicencesQueryTest : Base
{
    [Fact]
    public async Task GetLicencePageableQuery_Filters_ReturnLicencePageableList()
    {
        
        //Given(Arrange)= what is part of request
        var licence = new LicenceBuilder().Build();
        await licence.SaveAsync();
        
        //When (Act) - what we do with that data

        var handler = new GetLicencePageableQueryHandler(Mapper);
        var query = new GetLicencePageableQueryBuilder().Build();
        var response = await handler.Handle(query, new CancellationToken());
        
        
        //Then (Assert) - what is response

        using var _ = new AssertionScope();
        response.Should().NotBeNull();
        response.Licences.Should().NotBeNull();
        response.Licences.Should().HaveCount(1);

        await DB.Database("LicenceShopTests").Client.DropDatabaseAsync("LicenceShopTests");


    }
    
}