using OnlineShopping.Domain.AggregatesModel.BuyerAggregate;
using OnlineShopping.WebApi.ViewModels.BuyerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.WebApi.Mappers
{
    public static class BuyerToViewModel
    {
        public static BuyerViewModel ToViewModel(this Buyer buyer)
        {
            return new BuyerViewModel
            {
                id = buyer.Id,
                Firstname = buyer.Firstname,
                Lastname = buyer.Lastname,
                Nationalcode = buyer.Nationalcode,
            };
        }
    }
}
