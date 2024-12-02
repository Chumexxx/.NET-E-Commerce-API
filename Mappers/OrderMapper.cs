using ECommerce.DTOs.Item;
using ECommerce.DTOs.Order;
using ECommerce.DTOs.OrderedItem;
using ECommerce.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order orderModel)
        {
            return new OrderDto
            {
                OrderId = orderModel.OrderId,
                OrderedBy = orderModel.AppUser.UserName,
                ShippingAddress = orderModel.AppUser.HomeAddress,
                PaymentMethod = orderModel.PaymentMethod,
                IsReturned = orderModel.IsReturned,
                IsCancelled = orderModel.IsCancelled,
                OrderDate = orderModel.OrderDate,
                TotalBill = orderModel.TotalBill,
                OrderedItems = orderModel.OrderedItems.Select(i => i.ToOrderedItemDto()).ToList()
            };

        }

        public static Order ToOrderFromCreateDto(this CreateOrderRequestDto orderDto)
        {
            return new Order
            {
                ShippingAddress = orderDto.ShippingAddress,
                PaymentMethod = orderDto.PaymentMethod,
                OrderedItems = new List<OrderedItem>(),
            };
        }

    }
}


