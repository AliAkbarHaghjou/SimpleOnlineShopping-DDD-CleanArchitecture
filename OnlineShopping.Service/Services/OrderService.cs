using OnlineShopping.Application.Repositories;
using OnlineShopping.Application.Services;
using OnlineShopping.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositry _orderRepositry;

        public OrderService(IOrderRepositry orderRepositry)
        {
            _orderRepositry = orderRepositry;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepositry.GetAll();
        }

        public async ValueTask<Order> GetOrderByID(int OrderID)
        {
            return await _orderRepositry.Find(OrderID);
        }

        public async Task<Order> CreateOrder(Order Entity)
        {
            var result = await _orderRepositry.Add(Entity);
            await _orderRepositry.SaveChanges();
            return result;
        }

        public async Task<Order> UpdateOrder(Order Entity, int Id)
        {
            var result = await _orderRepositry.Find(Id);
            if (result == null) throw new ArgumentNullException();
            result.SetBuyerId(Entity.BuyerId).SetProductName(Entity.ProductName).SetDescription(Entity.Description).SetOrderDate(Entity.OrderDate);
            result = _orderRepositry.Update(result);
            await _orderRepositry.SaveChanges();
            return result;

        }

        public async Task<Order> DeleteOrder(int OrderID)
        {
            var result = await _orderRepositry.Find(OrderID);
            if (result == null) throw new ArgumentNullException();
            result = _orderRepositry.Remove(result);
            await _orderRepositry.SaveChanges();
            return result;
        }
    }
}
