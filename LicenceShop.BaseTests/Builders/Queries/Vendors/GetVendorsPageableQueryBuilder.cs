using LicenceShop.Application.Vendor.Queries;

namespace LicenceShop.BaseTests.Builders.Queries.Vendors;

public class GetVendorsPageableQueryBuilder
{
    private int _pageSize = 7;
    private int _pageNumber = 1;
    private string _searchQuery = "";
 
    public GetVendorsPageableQuery Build() => new(_pageNumber, _pageSize, _searchQuery);

    public GetVendorsPageableQueryBuilder withPageSize(int pageSize)
    {
        _pageSize = pageSize;
        return this;
    }

    
    public GetVendorsPageableQueryBuilder withPageNumber(int pageNumber)
    {
        _pageNumber = pageNumber;
        return this;
    }
    
    public GetVendorsPageableQueryBuilder withPageQuery(string searchQuery)
    {
        _searchQuery = searchQuery;
        return this;
    }
}