using OnlineShopping.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.AggregatesModel.BuyerAggregate
{
    public class ContactInfo : ValueObject
    {
        public int Id { get; set; }
        public int Buyerid { get; private set; }
        public string Address { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }

        public Buyer buyer { get; private set; }

        public ContactInfo(string address, string email, string mobile)
        {
            Address = address;
            Email = email;
            Mobile = mobile;
        }

        public ContactInfo SetId(int id)
        {
            Id = id;
            return this;
        }


        public ContactInfo SetUserId(int buyerid)
        {
            Buyerid = buyerid;
            return this;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Buyerid;
            yield return Address;
            yield return Email;
            yield return Mobile;
        }
    }
}
