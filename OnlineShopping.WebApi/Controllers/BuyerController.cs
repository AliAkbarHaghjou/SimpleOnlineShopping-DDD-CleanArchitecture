using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Application.Repositories;
using OnlineShopping.Application.Services;
using OnlineShopping.Domain.AggregatesModel.BuyerAggregate;
using OnlineShopping.WebApi.Mappers;
using OnlineShopping.WebApi.ViewModels.BuyerViewModels;
using OnlineShopping.WebApi.ViewModels.ContactInfoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuyerController : Controller
    {
        private readonly IBuyerService _buyerService;

        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> GetBuyers()
        {
            var result = await _buyerService.GetAllBuyers();
            return Ok(result.Select(x => x.ToViewModel()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> GetBuyerById(int id)
        {
            var result = await _buyerService.GetBuyerByID(id);
            return Ok(result.ToViewModel());
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> AddBuyer(CreateUpdateBuyerViewModel model)
        {
            var result = await _buyerService.CreateBuyer(new Buyer(model.Firstname, model.Lastname, model.Nationalcode));
            return CreatedAtAction(nameof(GetBuyerById), new { id = result.Id }, result.ToViewModel());
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> UpdateBuyer(int id, CreateUpdateBuyerViewModel model)
        {
            var result = await _buyerService.UpdateBuyer(new Buyer(model.Firstname, model.Lastname, model.Nationalcode), id);
            return Ok(result.ToViewModel());
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> DeleteBuyer(int id)
        {
            var result = await _buyerService.DeleteBuyer(id);
            return Ok(result.ToViewModel());
        }

        [HttpGet("{buyerId}/ContactInfo")]
        public async Task<ActionResult<IEnumerable<ContactInfoViewModel>>> GetAllContactInfoByBuyerID(int buyerId)
        {
            return Ok(await _buyerService.GetAllContactInfos(buyerId));
        }

        [HttpPost("{buyerId}/ContactInfo")]
        public async Task<ActionResult<IEnumerable<ContactInfoViewModel>>> AddContactInfo(int buyerId, CreateUpdateContactInfoViewModel model)
        {
            var ContactInfo = await _buyerService.AddContactInfo(buyerId, new ContactInfo(model.address, model.email, model.mobile));
            return Ok(ContactInfo.ToViewModel());
        }


        [HttpDelete("{buyerId}/ContactInfo/contactinfoId")]
        public async Task<ActionResult<IEnumerable<ContactInfoViewModel>>> DeleteContactInfo(int contactinfoId, int buyerId)
        {
            var ContactInfo = await _buyerService.DeleteContactInfo(contactinfoId, buyerId);
            return Ok(ContactInfo.ToViewModel());
        }
    }
}
