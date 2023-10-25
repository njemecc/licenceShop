using AutoMapper;
using LicenceShop.Application.Common.Dto.Order;
using LicenceShop.Application.Common.Exceptions;
using LicenceShop.Application.Common.Interfaces;
using LicenceShop.Application.Enums;
using LicenceShop.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Order.Commands;

public record CreateOrderCommand(CreateOrderDto Order) : IRequest<string>;


public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
{

    private readonly IUserService _userService;
    
    public CreateOrderCommandHandler(IUserService userService)
    {
        _userService = userService;
    }


    public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        
        var rnd = new Random();
        var orderCode = (long)rnd.Next(0, 999999999);

        var customer = await _userService.GetUserAsync(request.Order.CustomerId);
        if (customer == null) throw new NotFoundException("Customer not found");
        
        var licences = new List<Domain.Entities.Licence>();
        foreach (var item in request.Order.LicenceIds)
        {
            var licence = await DB.Find<Domain.Entities.Licence>().OneAsync(item, cancellation: cancellationToken);
            
            if (licence == null)
            {
                throw new Exception("User not found");
            }

            licences.Add(licence);
        }

        var order = new Domain.Entities.Order()
        {
            OrderCode = orderCode,
            Customer = customer,
            Licences = licences,
            TotalPrice = 0,
            Status = "Approved",
            Active = true
        };
        
        order.AddTotalPrice();

        foreach (var licence in licences)
        {
            if (licence.Owner.Email == null) continue;
            var seller = await _userService.GetUserByEmailAsync(licence.Owner.Email);
            if (seller == null) continue;
            seller.Balance += licence.Price;
            await _userService.UpdateUserAsync(seller);
        }
        

        if (order.TotalPrice > customer.Balance)
        {
            order.Status = "Rejected";
            order.Active = false;
        }
        
        
        if (customer.Balance >= order.TotalPrice)
        {
            customer.Balance -= order.TotalPrice;
            customer.Licences.AddRange(licences);
            
        }
        
        await _userService.UpdateUserAsync(customer);
        
        await order.SaveAsync(cancellation: cancellationToken);

        return "Order was successfully created";

    }
}