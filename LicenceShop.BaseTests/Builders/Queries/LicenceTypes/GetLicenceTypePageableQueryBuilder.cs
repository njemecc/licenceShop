using LicenceShop.Application.LicenceType.Queries;

namespace LicenceShop.BaseTests.Builders.Queries.LicenceTypes;

public class GetLicenceTypePageableQueryBuilder
{
    private int _pageSize = 7;
    private int _pageNumber = 1;
    private string _searchQuery = "";
 
    public GetLicenceTypePageableQuery Build() => new(_pageNumber, _pageSize, _searchQuery);

    public GetLicenceTypePageableQueryBuilder withPageSize(int pageSize)
    {
        _pageSize = pageSize;
        return this;
    }

    
    public GetLicenceTypePageableQueryBuilder withPageNumber(int pageNumber)
    {
        _pageNumber = pageNumber;
        return this;
    }
    
    public GetLicenceTypePageableQueryBuilder withPageQuery(string searchQuery)
    {
        _searchQuery = searchQuery;
        return this;
    }
}