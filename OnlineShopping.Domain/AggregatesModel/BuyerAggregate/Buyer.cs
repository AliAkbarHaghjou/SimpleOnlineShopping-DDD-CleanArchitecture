using OnlineShopping.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.AggregatesModel.BuyerAggregate
{
    public class Buyer : Entity
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Nationalcode { get; private set; }

        private List<ContactInfo> contactinfos = new List<ContactInfo>();

        public IReadOnlyList<ContactInfo> ContactInfos => contactinfos.ToList();


        public Buyer(string firstname, string lastname, string nationalcode)
        {
            if (string.IsNullOrEmpty(firstname)) throw new ArgumentNullException(nameof(firstname));
            if (string.IsNullOrEmpty(lastname)) throw new ArgumentNullException(nameof(lastname));
            if (string.IsNullOrEmpty(nationalcode)) throw new ArgumentNullException(nameof(nationalcode));


            Firstname = firstname;
            Lastname = lastname;
            Nationalcode = nationalcode;
        }

        public Buyer SetId(int id)
        {
            this.Id = id;
            return this;
        }

        public Buyer SetFirstname(string firstname)
        {
            if (string.IsNullOrEmpty(firstname)) throw new ArgumentNullException(nameof(firstname));
            Firstname = firstname;
            return this;
        }
        public Buyer SetLastname(string lastname)
        {
            if (string.IsNullOrEmpty(lastname)) throw new ArgumentNullException(nameof(lastname));
            Lastname = lastname;
            return this;
        }
        public Buyer SetNationalcode(string nationalcode)
        {
            if (string.IsNullOrEmpty(nationalcode)) throw new ArgumentNullException(nameof(nationalcode));
            Nationalcode = nationalcode;
            return this;
        }


        public ContactInfo AddContactInfo(string address, string email, string mobile)
        {
            if (string.IsNullOrEmpty(address)) throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));
            if (string.IsNullOrEmpty(mobile)) throw new ArgumentNullException(nameof(mobile));

            var newContactinfo = new ContactInfo(address, email, mobile);

            if (contactinfos.Any(x => x == newContactinfo))
            {
                throw new ArgumentException("This data already exist");
            }

            contactinfos.Add(newContactinfo);
            return newContactinfo;
        }

        public ContactInfo RemoveContactInfo(int contactinfoId)
        {
            var contactinfo = contactinfos.Find(x => x.Id == contactinfoId);
            if (contactinfo == null) throw new Exception("This Contactinfo doesn`t exist");

            contactinfos.Remove(contactinfo);
            return contactinfo;
        }
    }
}
