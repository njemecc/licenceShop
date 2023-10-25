using AutoMapper;
using LicenceShop.Application.Common.Dto.Car;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace LicenceShop.Application.Car.Queries;

public record GetAllCarsQuery() : IRequest<CarListDto>;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, CarListDto>
{

    private readonly IMapper _mapper;
    
    public GetAllCarsQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }


    public async Task<CarListDto> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<CarListDto>(await DB.Find<Domain.Entities.Car>()
            .ExecuteAsync(cancellation: cancellationToken));

    }
}


