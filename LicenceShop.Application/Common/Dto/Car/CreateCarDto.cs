using LicenceShop.Domain.Entities;

namespace LicenceShop.Application.Common.Dto.Car;

public record CreateCarDto(string Name, string VendorId, int YearProduction, bool Active, List<string> UserIds, List<string>OtherUsersIds);