using LicenceShop.Application.Category.Queries;

namespace LicenceShop.BaseTests.Builders.Queries.Categories;

public class GetCategoryPageableQueryBuilder
{
    private int _pageSize = 7;
    private int _pageNumber = 1;
    private string _searchQuery = "";
 
    public GetPageableCategoryQuery Build() => new(_pageNumber, _pageSize, _searchQuery);

    public GetCategoryPageableQueryBuilder withPageSize(int pageSize)
    {
        _pageSize = pageSize;
        return this;
    }

    
    public GetCategoryPageableQueryBuilder withPageNumber(int pageNumber)
    {
        _pageNumber = pageNumber;
        return this;
    }
    
    public GetCategoryPageableQueryBuilder withPageQuery(string searchQuery)
    {
        _searchQuery = searchQuery;
        return this;
    }
}