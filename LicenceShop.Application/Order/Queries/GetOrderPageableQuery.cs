using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.Order;
using LicenceShop.Application.Extensions.Order;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Order.Queries;

public record GetOrderPageableQuery(int PageNumber, int PageSize, string? Search) : IRequest<OrderPageableDto>;

public class GetOrderPageableQueryHandler : IRequestHandler<GetOrderPageableQuery, OrderPageableDto>
{

    private readonly IMapper _mapper;

    public GetOrderPageableQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<OrderPageableDto> Handle(GetOrderPageableQuery request, CancellationToken cancellationToken)
    {
        var users = await DB.PagedSearch<Domain.Entities.Order>()
            .Sort(b => b.OrderCode, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);
        return _mapper.Map<OrderPageableDto>(users.Results).AddPagination(new PaginationDto(users.TotalCount, users.PageCount));
    }
}