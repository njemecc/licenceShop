using LicenceShop.Application.Car.Queries;
using MongoDB.Entities;

namespace LicenceShop.Application.Extensions.Car;

public static class CarFilterExtensions
{
    public static PagedSearch<Domain.Entities.Car, Domain.Entities.Car> ApplyFilters(this PagedSearch<Domain.Entities.Car, Domain.Entities.Car> query, GetCarsPageableQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.Search))
        {
            query = (PagedSearch<Domain.Entities.Car>)query.Match(x => x.Name.ToUpper().Contains(filters.Search.ToUpper()));
        }        
        
        return query;
    }
}