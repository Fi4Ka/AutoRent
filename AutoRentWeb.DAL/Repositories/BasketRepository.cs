using AutoRentWeb.DAL.Context;
using AutoRentWeb.DAL.Interfaces;
using AutoRentWebDomain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWeb.DAL.Repositories
{
    public class BasketRepository : IRepository<Basket>
    {

        public AutoRentDbContext AutoRentDbContext { get; set; }
        public BasketRepository(AutoRentDbContext autoRentDbContext)
        {
            AutoRentDbContext = autoRentDbContext;
        }
        public async Task Create(Basket entity)
        {
            await AutoRentDbContext.Basket.AddAsync(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public async Task Delete(Basket entity)
        {
            AutoRentDbContext.Basket.Remove(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public IEnumerable<Basket> GetAll()
        {
            return AutoRentDbContext.Basket.Include(x=>x.Orders);
        }


        public async Task<Basket> Update(Basket entity)
        {
            AutoRentDbContext.Basket.Update(entity);
            await AutoRentDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
