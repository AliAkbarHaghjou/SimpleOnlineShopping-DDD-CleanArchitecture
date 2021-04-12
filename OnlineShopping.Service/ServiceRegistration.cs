using Microsoft.Extensions.DependencyInjection;
using OnlineShopping.Application.Services;
using OnlineShopping.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Service
{
    public static class ServiceRegistration
    {
        public static void AddServiceInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBuyerService, BuyerService>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
