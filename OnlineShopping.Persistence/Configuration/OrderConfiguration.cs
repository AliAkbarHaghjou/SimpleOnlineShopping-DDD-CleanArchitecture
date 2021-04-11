using Microsoft.EntityFrameworkCore;
using OnlineShopping.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Persistence.Configuration
{
    public class OrderConfiguration
    {
        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).ValueGeneratedOnAdd();
                x.HasIndex(x => x.Id).IsUnique(true);

                x.Property(x => x.BuyerId).IsRequired();
                x.Property(x => x.ProductName).IsRequired();
                x.Property(x => x.Description).IsRequired();
                x.Property(x => x.OrderDate).IsRequired();
            });
        }

    }
}
