using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.Car;

namespace LicenceShop.Application.Mappers.Cars;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UpdateCarDto, Domain.Entities.Car>().ReverseMap();
        CreateMap<Domain.Entities.Car, Task<CarDetailsDto>>().ConstructUsing(x => GetCarDetails(x));
        CreateMap<IEnumerable<Domain.Entities.Car>, CarListDto>().ConstructUsing(x => GetCarList(x));
        CreateMap<IEnumerable<Domain.Entities.Car>, CarPageableDto>().ConstructUsing(x => GetCarPageableList(x));


    }

    private static async Task<CarDetailsDto> GetCarDetails(Domain.Entities.Car car)
    {
        return
            new CarDetailsDto
            (
                car.Name,
                car.YearProduction,
                car.Active,
                (await car.Vendor.ToEntityAsync())!.Name,
                car.Users.Select(x => x.Email),
                car.OtherUsers.Select(x => x.Email)
            );
    }

    private static CarListDto GetCarList(IEnumerable<Domain.Entities.Car> cars)
    {
        var carList = cars.Select(x => GetCarDetails(x).Result).ToList();
        return new CarListDto(carList);
    }
    
    
    private static CarPageableDto GetCarPageableList (IEnumerable<Domain.Entities.Car> cars)
    {
        var carList = cars.Select(x => GetCarDetails(x).Result).ToList();
        return new CarPageableDto(carList, new PaginationDto(0, 0));
    }



}