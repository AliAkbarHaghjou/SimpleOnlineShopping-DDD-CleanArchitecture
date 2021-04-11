﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.WebApi.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int id { get; set; }
        public int BuyerId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string OrderDate { get; set; }
    }
}
