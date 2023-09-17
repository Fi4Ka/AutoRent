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
    internal class ArendatorRepository : IRepository<Arendator>
    {
        public AutoRentDbContext AutoRentDbContext { get; set; }
        public ArendatorRepository(AutoRentDbContext autoRentDbContext)
        {
            AutoRentDbContext = autoRentDbContext;
        }
        public async Task Create(Arendator entity)
        {
            await AutoRentDbContext.Arendator.AddAsync(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public async Task Delete(Arendator entity)
        {
            AutoRentDbContext.Arendator.Remove(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public IEnumerable<Arendator> GetAll()
        {
            return AutoRentDbContext.Arendator.Include(x => x.Basket.Orders).Include(x => x.User).Include(x=>x.Basket);
        }


        public async Task<Arendator> Update(Arendator entity)
        {
            AutoRentDbContext.Arendator.Update(entity);
            await AutoRentDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
