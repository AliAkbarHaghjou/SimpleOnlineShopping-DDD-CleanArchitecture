using OnlineShopping.Application.Repositories;
using OnlineShopping.Application.Services;
using OnlineShopping.Domain.AggregatesModel.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Service.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepositry _buyerRepositry;

        public BuyerService(IBuyerRepositry buyerRepositry)
        {
            _buyerRepositry = buyerRepositry;
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyers()
        {
            return await _buyerRepositry.GetAll();
        }

        public async ValueTask<Buyer> GetBuyerByID(int BuyerID)
        {
            var result = await _buyerRepositry.Find(BuyerID);
            if (result == null) throw new ArgumentNullException();
            return result;
        }

        public async Task<Buyer> CreateBuyer(Buyer Entity)
        {
            var result = await _buyerRepositry.Add(Entity);
            await _buyerRepositry.SaveChanges();
            return result;
        }

        public async Task<Buyer> UpdateBuyer(Buyer Entity, int Id)
        {
            var result = await _buyerRepositry.Find(Id);
            if (result == null) throw new ArgumentNullException();
            result.SetFirstname(Entity.Firstname).SetLastname(Entity.Lastname).SetNationalcode(Entity.Nationalcode);
            result = _buyerRepositry.Update(Entity);
            await _buyerRepositry.SaveChanges();
            return result;
        }

        public async Task<Buyer> DeleteBuyer(int BuyerID)
        {
            var result = await _buyerRepositry.Find(BuyerID);
            if (result == null) throw new ArgumentNullException();
            result = _buyerRepositry.Remove(result);
            await _buyerRepositry.SaveChanges();
            return result;
        }


        public async Task<ICollection<ContactInfo>> GetAllContactInfos(int buyerId)
        {
            return await _buyerRepositry.GetAllContactInfos(buyerId);
        }

        public async Task<ContactInfo> AddContactInfo(int buyerId, ContactInfo model)
        {
            var buyer = await _buyerRepositry.Find(buyerId);
            if (buyer == null) throw new ArgumentNullException();
            var ContactInfo = _buyerRepositry.AddContactInfo(buyer, model.Address, model.Email, model.Mobile);
            await _buyerRepositry.SaveChanges();
            return ContactInfo;
        }

        public async Task<ContactInfo> DeleteContactInfo(int contactinfoId, int buyerId)
        {
            var buyer = await _buyerRepositry.Find(buyerId);
            if (buyer == null) throw new ArgumentNullException();
            var ContactInfo = _buyerRepositry.RemoveContactInfo(buyer, contactinfoId);
            await _buyerRepositry.SaveChanges();
            return ContactInfo;
        }
    }
}
