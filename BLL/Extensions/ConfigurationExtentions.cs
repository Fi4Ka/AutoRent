using AutoMapper;
using BLL.DTO;
using BLL.Interfaces.EntityServices;
using BLL.Profiles;
using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Extensions
{
    public static class ConfigurationExtentions
    {
        public static void ConfigureBLL(this IServiceCollection services, IConfiguration configuration)
        {
            AutoRentWeb.DAL.Extensions.ConfigurationExtensions.ConfigureDAL(services, configuration);

              IMapper mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ArendatorProfile());
                mc.AddProfile(new AutoProfile());
                mc.AddProfile(new CompanyDelegateProfile());
                mc.AddProfile(new BasketProfile());
                mc.AddProfile(new CompanyProfile());
                mc.AddProfile(new OrderProfile());
                mc.AddProfile(new TypeCarProfile());
                mc.AddProfile(new UserProfile());
            }).CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IArendatorService, ArendatorService>();
            services.AddTransient<IAutoService<AutoDTO>, AutoService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserSrvice, UserService>();
            services.AddTransient<IStatisticService, StatisticService>();

        }
    }
}
