using LicenceShop.Application.Common.Dto.Licence;

namespace LicenceShop.Application.Common.Dto.Order;

public record OrderDetailsDto(long OrderCode, string? Customer, double TotalPrice,
    string Status, OrderInfoDto OrderInfo)
{
    internal OrderDetailsDto AddOrderInfo(OrderInfoDto orderInfo)
    {
        return this with { OrderInfo = orderInfo};
    }
    
};