using LicenceShop.Application.LicenceType.Queries;
using LicenceShop.Application.Vendor.Queries;
using MongoDB.Entities;

namespace LicenceShop.Application.Extensions.LicenceType;

public static class LicenceTypeFilterExtensions
{
    public static PagedSearch<Domain.Entities.LicenceType, Domain.Entities.LicenceType> ApplyFilters(this PagedSearch<Domain.Entities.LicenceType, Domain.Entities.LicenceType> query, GetLicenceTypePageableQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.Search))
        {
            query = (PagedSearch<Domain.Entities.LicenceType>)query.Match(x => x.Name.Contains(filters.Search));
        }        
        
        return query;
    }
}