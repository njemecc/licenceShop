namespace LicenceShop.Application.Common.Dto.Order;

public record OrderInfoDto(IEnumerable<string> Licence, IEnumerable<string?> Seller);
