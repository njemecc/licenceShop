namespace LicenceShop.Application.Common.Dto.Car;

public record UpdateCarDto(string CarId, string Name, int YearProduction, bool Active);