using OnlineShopping.Domain.AggregatesModel.BuyerAggregate;
using OnlineShopping.WebApi.ViewModels.BuyerViewModels;
using OnlineShopping.WebApi.ViewModels.ContactInfoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.WebApi.Mappers
{
    public static class ContactInfoToViewModel
    {
        public static ContactInfoViewModel ToViewModel(this ContactInfo contactInfo)
        {
            return new ContactInfoViewModel
            {
                id = contactInfo.Id,
                Buyerid = contactInfo.Buyerid,
                address = contactInfo.Address,
                email = contactInfo.Email,
                mobile = contactInfo.Mobile,
            };
        }
    }
}
