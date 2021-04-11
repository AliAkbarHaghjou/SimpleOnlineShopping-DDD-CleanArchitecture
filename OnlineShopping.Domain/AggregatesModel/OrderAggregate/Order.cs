using OnlineShopping.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.AggregatesModel.OrderAggregate
{
    public class Order : Entity
    {
        public int BuyerId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public string OrderDate { get; private set; }


        public Order(int buyerId, string productName, string description, string orderDate)
        {
            if (buyerId == 0) throw new ArgumentOutOfRangeException();
            if (string.IsNullOrEmpty(productName)) throw new ArgumentNullException(nameof(productName));
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));
            if (string.IsNullOrEmpty(orderDate)) throw new ArgumentNullException(nameof(orderDate));

            BuyerId = buyerId;
            ProductName = productName;
            Description = description;
            OrderDate = orderDate;
        }


        public Order SetId(int id)
        {
            this.Id = id;
            return this;
        }

        public Order SetBuyerId(int buyerId)
        {
            this.BuyerId = buyerId;
            return this;
        }

        public Order SetProductName(string productname)
        {
            if (string.IsNullOrEmpty(productname)) throw new ArgumentNullException(nameof(productname));
            ProductName = productname;
            return this;
        }
        public Order SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));
            Description = description;
            return this;
        }
        public Order SetOrderDate(string orderDate)
        {
            if (string.IsNullOrEmpty(orderDate)) throw new ArgumentNullException(nameof(orderDate));
            OrderDate = orderDate;
            return this;
        }

    }
}
