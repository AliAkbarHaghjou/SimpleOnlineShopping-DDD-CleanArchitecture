using OnlineShopping.Application.Repositories;
using OnlineShopping.Domain.AggregatesModel.OrderAggregate;
using OnlineShopping.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Persistence.Repository
{
    public class OrderRepositry : BaseRepository<Order>, IOrderRepositry
    {
        public OrderRepositry(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
