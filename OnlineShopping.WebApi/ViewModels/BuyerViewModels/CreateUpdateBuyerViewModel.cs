using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.WebApi.ViewModels.BuyerViewModels
{
    public class CreateUpdateBuyerViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nationalcode { get; set; }
    }
}
