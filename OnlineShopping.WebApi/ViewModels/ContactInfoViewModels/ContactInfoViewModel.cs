using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.WebApi.ViewModels.ContactInfoViewModels
{
    public class ContactInfoViewModel
    {
        public int id { get; set; }
        public int Buyerid { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
    }
}
