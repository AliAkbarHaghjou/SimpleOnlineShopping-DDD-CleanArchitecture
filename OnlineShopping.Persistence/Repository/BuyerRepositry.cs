using OnlineShopping.Application.Repositories;
using OnlineShopping.Domain.AggregatesModel.BuyerAggregate;
using OnlineShopping.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Persistence.Repository
{
    public class BuyerRepositry : BaseRepository<Buyer>, IBuyerRepositry
    {

        private readonly DbSet<ContactInfo> ContactInfos;
        public BuyerRepositry(ApplicationDbContext dbContext) : base(dbContext)
        {
            ContactInfos = dbContext.Set<ContactInfo>();
        }

        public override async Task<Buyer> Find(int Id)
        {
            return await entities.Include(x => x.ContactInfos).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public virtual async Task<ICollection<ContactInfo>> GetAllContactInfos(int buyerId)
        {
            return await ContactInfos.Where(x => x.Buyerid == buyerId).ToListAsync();
        }

        public ContactInfo AddContactInfo(Buyer buyer, string address, string email, string mobile)
        {
            return buyer.AddContactInfo(address, email, mobile);
        }
        public ContactInfo RemoveContactInfo(Buyer buyer, int contactinfoID)
        {
            return buyer.RemoveContactInfo(contactinfoID);
        }
    }
}
