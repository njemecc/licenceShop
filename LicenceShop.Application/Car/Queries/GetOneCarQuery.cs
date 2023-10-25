using AutoMapper;
using LicenceShop.Application.Common.Dto.Car;
using LicenceShop.Application.Common.Exceptions;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace LicenceShop.Application.Car.Queries;

//Query
public record GetOneCarQuery(string CarId) : IRequest<CarDetailsDto>;

//Query HANDLER
public class GetCarOneQueryHandler : IRequestHandler<GetOneCarQuery, CarDetailsDto>
{

    private readonly IMapper _mapper;

    public GetCarOneQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    


    public async Task<CarDetailsDto> Handle(GetOneCarQuery request, CancellationToken cancellationToken)
    {
        var car = await DB.Find<Domain.Entities.Car>().OneAsync(request.CarId, cancellation: cancellationToken);

        var car2 = await DB.Fluent<Domain.Entities.Car>().Match(x => x.ID != null && x.ID.Equals(request.CarId))
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        
        if (car == null) throw new NotFoundException("Car not found");
        return await _mapper.Map<Task<CarDetailsDto>>(car);
    }
}