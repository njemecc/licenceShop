using LicenceShop.Application.Licence.Queries;
using LicenceShop.Application.LicenceType.Queries;
using LicenceShop.Application.Vendor.Queries;
using MongoDB.Entities;

namespace LicenceShop.Application.Extensions.Licence;

public static class LicenceFilterExtensions
{
    public static PagedSearch<Domain.Entities.Licence, Domain.Entities.Licence> ApplyFilters(this PagedSearch<Domain.Entities.Licence, Domain.Entities.Licence> query, GetLicencePageableQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.Search))
        {
            query = (PagedSearch<Domain.Entities.Licence>)query.Match(x => x.Name.Contains(filters.Search));
        }        
        
        return query;
    }
}