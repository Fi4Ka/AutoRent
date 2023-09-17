using AutoRentWeb.DAL.Context;
using AutoRentWeb.DAL.Interfaces;
using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWeb.DAL.Repositories
{
    public class OrderRepository:IRepository<Order>
    {
        public AutoRentDbContext AutoRentDbContext { get; set; }
        public OrderRepository(AutoRentDbContext autoRentDbContext)
        {
            AutoRentDbContext = autoRentDbContext;
        }
        public async Task Create(Order entity)
        {
            await AutoRentDbContext.Order.AddAsync(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public async Task Delete(Order entity)
        {
            AutoRentDbContext.Order.Remove(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public IEnumerable<Order> GetAll()
        {
            return AutoRentDbContext.Order.Include(x => x.Auto.CompanyDelegate).Include(x => x.Basket);
        }

        public async Task<Order> Update(Order entity)
        {
            var order=AutoRentDbContext.Order.FirstOrDefault(x => x.Id == entity.Id);
            order.StatusOrder = StatusOrder.Completed;
            AutoRentDbContext.Order.Update(order);
            await AutoRentDbContext.SaveChangesAsync();
            return order;
        }
    }
}
