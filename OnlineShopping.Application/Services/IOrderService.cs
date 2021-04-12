using OnlineShopping.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Application.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        ValueTask<Order> GetOrderByID(int OrderID);
        Task<Order> CreateOrder(Order Entity);
        Task<Order> UpdateOrder(Order Entity, int Id);
        Task<Order> DeleteOrder(int OrderID);
    }
}
