using MongoDB.Entities;

namespace LicenceShop.Application.Common.Dto.Licence;

public record LicenceDetailsDto(string Name, DateTime StartDate, DateTime EndDate, string Vendor, string Category, string Type, string? Owner, bool IsSold, double Price, string Img, string Description);