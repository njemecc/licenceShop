using LicenceShop.Application.Order.Queries;
using LicenceShop.Application.Vendor.Queries;
using MongoDB.Entities;

namespace LicenceShop.Application.Extensions.Order;

public static class OrderFilterExtensionss
{
    public static PagedSearch<Domain.Entities.Order, Domain.Entities.Order> ApplyFilters(this PagedSearch<Domain.Entities.Order, Domain.Entities.Order> query, GetOrderPageableQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.Search))
        {
            query = (PagedSearch<Domain.Entities.Order>)query.Match(x => x.OrderCode.Equals(filters.Search));
        }        
        
        return query;
    }
}