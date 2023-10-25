using LicenceShop.Application.Common.Dto.Licence;

namespace LicenceShop.Application.Common.Dto.Order;

public record CreateOrderDto(string CustomerId, List<string> LicenceIds);
