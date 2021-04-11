using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Application.Repositories;
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
        private readonly IBuyerRepositry _buyerRepositry;

        public BuyerController(IBuyerRepositry buyerRepositry)
        {
            _buyerRepositry = buyerRepositry;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> Get()
        {
            var result = await _buyerRepositry.GetAll();
            return Ok(result.Select(x => x.ToViewModel()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> GetById(int id)
        {
            var result = await _buyerRepositry.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToViewModel());
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> Post(CreateUpdateBuyerViewModel model)
        {
            var result = await _buyerRepositry.Add(new Buyer(model.Firstname, model.Lastname, model.Nationalcode));
            await _buyerRepositry.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToViewModel());
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> Put(int id, CreateUpdateBuyerViewModel model)
        {
            var result = await _buyerRepositry.Find(id);
            if (result == null) return NotFound();
            result.SetFirstname(model.Firstname).SetLastname(model.Lastname).SetNationalcode(model.Nationalcode);
            result = _buyerRepositry.Update(result);
            await _buyerRepositry.SaveChanges();
            return Ok(result.ToViewModel());
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<BuyerViewModel>>> Delete(int id)
        {
            var result = await _buyerRepositry.Find(id);
            if (result == null) return NotFound();
            result = _buyerRepositry.Remove(result);
            await _buyerRepositry.SaveChanges();
            return Ok(result.ToViewModel());
        }

        [HttpGet("{buyerId}/ContactInfo")]
        public async Task<ActionResult<IEnumerable<ContactInfoViewModel>>> GetAllContactInfoByBuyerID(int buyerId)
        {
            return Ok(await _buyerRepositry.GetAllContactInfos(buyerId));
        }

        [HttpPost("{buyerId}/ContactInfo")]
        public async Task<ActionResult<IEnumerable<ContactInfoViewModel>>> AddContactInfo(int buyerId, CreateUpdateContactInfoViewModel model)
        {
            var buyer = await _buyerRepositry.Find(buyerId);
            if (buyer == null) return NotFound();
            var ContactInfo = _buyerRepositry.AddContactInfo(buyer, model.address, model.email, model.mobile);
            await _buyerRepositry.SaveChanges();
            return Ok(ContactInfo.ToViewModel());
        }


        [HttpDelete("{buyerId}/ContactInfo/contactinfoId")]
        public async Task<ActionResult<IEnumerable<ContactInfoViewModel>>> DeleteContactInfo(int contactinfoId, int buyerId)
        {
            var buyer = await _buyerRepositry.Find(buyerId);
            if (buyer == null) return NotFound();
            var ContactInfo = _buyerRepositry.RemoveContactInfo(buyer, contactinfoId);
            await _buyerRepositry.SaveChanges();
            return Ok(ContactInfo.ToViewModel());
        }
    }
}
