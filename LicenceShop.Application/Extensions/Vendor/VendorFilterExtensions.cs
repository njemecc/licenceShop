using LicenceShop.Application.Vendor.Queries;
using MongoDB.Entities;

namespace LicenceShop.Application.Extensions.Vendor;

public static class VendorFilterExtensions
{
    public static PagedSearch<Domain.Entities.Vendor, Domain.Entities.Vendor> ApplyFilters(this PagedSearch<Domain.Entities.Vendor, Domain.Entities.Vendor> query, GetVendorsPageableQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.Search))
        {
            query = (PagedSearch<Domain.Entities.Vendor>)query.Match(x => x.Name.Contains(filters.Search));
        }        
        
        return query;
    }
}
