using AutoMapper;
using LicenceShop.Application.Common.Dto.Car;
using LicenceShop.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Car.Commands;

public record UpdateCarCommand(UpdateCarDto Car) : IRequest<string>;


public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, string>
{
    private readonly IMapper _mapper;

    public UpdateCarCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await DB.Find<Domain.Entities.Car>().OneAsync(request.Car.CarId, cancellation: cancellationToken);
        if (car == null) throw new NotFoundException("Car not found");
        _mapper.Map(request.Car, car);
        await car.SaveAsync(cancellation: cancellationToken);
        return "Car was successfully updated";
    }
}