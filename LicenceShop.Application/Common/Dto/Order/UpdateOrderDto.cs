using LicenceShop.Application.Common.Dto.Licence;

namespace LicenceShop.Application.Common.Dto.Order;

public record UpdateOrderDto(string OrderId, IEnumerable<string?> Customer,  IEnumerable<string?> Licences, double? TotalPrice, string? Status);