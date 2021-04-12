using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Application.Repositories;
using OnlineShopping.Application.Services;
using OnlineShopping.Domain.AggregatesModel.OrderAggregate;
using OnlineShopping.WebApi.Mappers;
using OnlineShopping.WebApi.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetOrders()
        {
            var result = await _orderService.GetAllOrders();
            return Ok(result.Select(x => x.ToViewModel()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetOrderById(int id)
        {
            var result = await _orderService.GetOrderByID(id);
            return Ok(result.ToViewModel());
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> AddOrder(CreateUpdateOrderViewModel model)
        {
            var result = await _orderService.CreateOrder(new Order(model.BuyerId, model.ProductName, model.Description, model.OrderDate));
            return CreatedAtAction(nameof(GetOrderById), new { id = result.Id }, result.ToViewModel());
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> UpdateOrder(int id, CreateUpdateOrderViewModel model)
        {
            var result = await _orderService.UpdateOrder(new Order(model.BuyerId, model.ProductName, model.Description, model.OrderDate), id);
            return Ok(result.ToViewModel());
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            return Ok(result.ToViewModel());
        }
    }
}
