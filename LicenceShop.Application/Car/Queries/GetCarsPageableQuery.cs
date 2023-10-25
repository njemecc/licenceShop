using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.Car;
using MediatR;
using MongoDB.Entities;
using LicenceShop.Application.Extensions.Car;

namespace LicenceShop.Application.Car.Queries;

public record GetCarsPageableQuery( int PageNumber, int PageSize, string? Search) : IRequest<CarPageableDto>;


public class GetAllCarsPageableQueryHandler : IRequestHandler<GetCarsPageableQuery, CarPageableDto>
{
    private readonly IMapper _mapper;

    public GetAllCarsPageableQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }


    public async Task<CarPageableDto> Handle(GetCarsPageableQuery request, CancellationToken cancellationToken)
    {
        var cars = await DB.PagedSearch<Domain.Entities.Car>()
            .Sort(b => b.Name, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);
        return _mapper.Map<CarPageableDto>(cars.Results).AddPagination(new PaginationDto(cars.TotalCount, cars.PageCount));
    }
}