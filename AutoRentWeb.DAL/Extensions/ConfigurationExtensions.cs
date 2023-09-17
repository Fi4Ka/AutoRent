using AutoRentWeb.DAL.Constants;
using AutoRentWeb.DAL.Context;
using AutoRentWeb.DAL.Interfaces;
using AutoRentWeb.DAL.Repositories;
using AutoRentWebDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWeb.DAL.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AutoRentDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString(DbConstants.ConnectionStringName)));

            services.AddScoped<IRepository<Auto>, AutoRepository>();
            services.AddScoped<IRepository<Arendator>, ArendatorRepository>();
            services.AddScoped<IRepository<Basket>, BasketRepository>();
            services.AddScoped<IRepository<CompanyDelegate>, CompanyDelegateRepository>();
            services.AddScoped<IRepository<Company>, CompanyRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<TypeCar>, TypeCarRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();

        }
    }
}
