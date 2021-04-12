using OnlineShopping.Domain.AggregatesModel.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Application.Services
{
    public interface IBuyerService
    {
        Task<IEnumerable<Buyer>> GetAllBuyers();
        ValueTask<Buyer> GetBuyerByID(int BuyerID);
        Task<Buyer> CreateBuyer(Buyer Entity);
        Task<Buyer> UpdateBuyer(Buyer Entity, int Id);
        Task<Buyer> DeleteBuyer(int BuyerID);
        Task<ICollection<ContactInfo>> GetAllContactInfos(int buyerId);
        Task<ContactInfo> AddContactInfo(int buyerId, ContactInfo model);
        Task<ContactInfo> DeleteContactInfo(int contactinfoId, int buyerId);
    }
}
