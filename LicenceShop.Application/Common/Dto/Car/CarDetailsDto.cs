using LicenceShop.Domain.Entities;

namespace LicenceShop.Application.Common.Dto.Car;

public record CarDetailsDto(string CarName, int YearProduction, bool Active, string VendorName, IEnumerable<string?> Users, IEnumerable<string?> OtherUsers);