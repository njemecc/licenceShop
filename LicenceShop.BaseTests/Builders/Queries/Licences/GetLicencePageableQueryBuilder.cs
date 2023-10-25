using LicenceShop.Application.Licence.Queries;

namespace LicenceShop.BaseTests.Builders.Queries.Licences;

public class GetLicencePageableQueryBuilder
{
    private int _pageSize = 7;
    private int _pageNumber = 1;
    private string _searchQuery = "";
 
    public GetLicencePageableQuery Build() => new(_pageNumber, _pageSize, _searchQuery);

    public GetLicencePageableQueryBuilder withPageSize(int pageSize)
    {
        _pageSize = pageSize;
        return this;
    }

    
    public GetLicencePageableQueryBuilder withPageNumber(int pageNumber)
    {
        _pageNumber = pageNumber;
        return this;
    }
    
    public GetLicencePageableQueryBuilder withPageQuery(string searchQuery)
    {
        _searchQuery = searchQuery;
        return this;
    }
}