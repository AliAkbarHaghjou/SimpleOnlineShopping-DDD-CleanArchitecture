using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Application.Repositories;
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
        private readonly IOrderRepositry _orderRepositry;

        public OrderController(IOrderRepositry orderRepositry)
        {
            _orderRepositry = orderRepositry;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> Get()
        {
            var result = await _orderRepositry.GetAll();
            return Ok(result.Select(x => x.ToViewModel()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetById(int id)
        {
            var result = await _orderRepositry.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToViewModel());
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> Post(CreateUpdateOrderViewModel model)
        {
            var result = await _orderRepositry.Add(new Order(model.BuyerId, model.ProductName, model.Description, model.OrderDate));
            await _orderRepositry.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToViewModel());
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> Put(int id, CreateUpdateOrderViewModel model)
        {
            var result = await _orderRepositry.Find(id);
            if (result == null) return NotFound();
            result.SetBuyerId(model.BuyerId).SetProductName(model.ProductName).SetDescription(model.Description).SetOrderDate(model.OrderDate);
            result = _orderRepositry.Update(result);
            await _orderRepositry.SaveChanges();
            return Ok(result.ToViewModel());
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> Delete(int id)
        {
            var result = await _orderRepositry.Find(id);
            if (result == null) return NotFound();
            result = _orderRepositry.Remove(result);
            await _orderRepositry.SaveChanges();
            return Ok(result.ToViewModel());
        }

    }
}
