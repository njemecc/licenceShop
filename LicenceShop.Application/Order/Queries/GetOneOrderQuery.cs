using AutoMapper;
using LicenceShop.Application.Common.Dto.Order;
using LicenceShop.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Order.Queries;

public record GetOneOrderQuery(string OrderId) : IRequest<OrderDetailsDto>;


public class GetOneOrderQueryHandler : IRequestHandler<GetOneOrderQuery, OrderDetailsDto>
{

    private readonly IMapper _mapper;

    public GetOneOrderQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<OrderDetailsDto> Handle(GetOneOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await DB.Find<Domain.Entities.Order>().OneAsync(request.OrderId, cancellation: cancellationToken);
        if (order == null) throw new NotFoundException("Order not found");
        return _mapper.Map<OrderDetailsDto>(order);
    }
}
