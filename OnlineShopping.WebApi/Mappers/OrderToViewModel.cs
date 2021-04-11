using OnlineShopping.Domain.AggregatesModel.OrderAggregate;
using OnlineShopping.WebApi.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.WebApi.Mappers
{
    public static class OrderToViewModel
    {
        public static OrderViewModel ToViewModel(this Order order)
        {
            return new OrderViewModel
            {
                id = order.Id,
                BuyerId = order.BuyerId,
                ProductName = order.ProductName,
                Description = order.Description,
                OrderDate = order.OrderDate
            };
        }

    }
}
