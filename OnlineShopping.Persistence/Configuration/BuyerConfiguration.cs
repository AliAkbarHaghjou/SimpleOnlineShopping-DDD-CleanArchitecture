using OnlineShopping.Domain.AggregatesModel.BuyerAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Persistence.Configuration
{
    public class BuyerConfiguration
    {

        public static void Config(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).ValueGeneratedOnAdd();
                x.HasIndex(x => x.Id).IsUnique(true);

                x.Property(x => x.Firstname).IsRequired();
                x.Property(x => x.Lastname).IsRequired();
                x.Property(x => x.Nationalcode).IsRequired();

                //x.HasMany(x => x.ContactInfos)
                //    .WithOne()
                //    .IsRequired()
                //    .HasForeignKey(x => x.Buyerid)
                //    .OnDelete(DeleteBehavior.Cascade);

                //x.Metadata
                //    .FindNavigation("Con")
                //    .SetPropertyAccessMode(PropertyAccessMode.Field);

                //x.HasMany(x => x.ContactInfos).WithOne(x => x.buyer).HasForeignKey(x => x.Buyerid).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ContactInfo>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id).ValueGeneratedOnAdd();

                x.Property(x => x.Address).IsRequired();
                x.Property(x => x.Email).IsRequired();
                x.Property(x => x.Mobile).IsRequired();

                x.HasOne(x => x.buyer).WithMany(x => x.ContactInfos).HasForeignKey(x => x.Buyerid).OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}
