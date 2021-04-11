using OnlineShopping.Domain.AggregatesModel.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Application.Repositories
{
    public interface IBuyerRepositry : IBaseRepository<Buyer>
    {
        Task<ICollection<ContactInfo>> GetAllContactInfos(int buyerId);

        ContactInfo AddContactInfo(Buyer buyer, string address, string email, string mobile);

        ContactInfo RemoveContactInfo(Buyer buyer, int contactinfoID);
    }
}
