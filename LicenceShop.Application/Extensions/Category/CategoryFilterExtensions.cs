using LicenceShop.Application.Category.Queries;
using LicenceShop.Application.Vendor.Queries;
using MongoDB.Entities;

namespace LicenceShop.Application.Extensions.Category;

public static class CategoryFilterExtensions
{
    public static PagedSearch<Domain.Entities.Category, Domain.Entities.Category> ApplyFilters(this PagedSearch<Domain.Entities.Category, Domain.Entities.Category> query, GetPageableCategoryQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.Search))
        {
            query = (PagedSearch<Domain.Entities.Category>)query.Match(x => x.Name.Contains(filters.Search));
        }        
        
        return query;
    }
}