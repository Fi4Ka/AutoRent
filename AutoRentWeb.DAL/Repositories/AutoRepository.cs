using AutoRentWeb.DAL.Context;
using AutoRentWebDomain.Entity;
using AutoRentWeb.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutoRentWeb.DAL.Repositories
{
    public class AutoRepository : IRepository<Auto>
    {
        public AutoRentDbContext AutoRentDbContext { get; set; }
        public AutoRepository(AutoRentDbContext autoRentDbContext) 
        {
        AutoRentDbContext = autoRentDbContext;
        }
        public async Task Create(Auto entity)
        {
            await AutoRentDbContext.Auto.AddAsync(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public IEnumerable<Auto> GetAll()
        {
            return AutoRentDbContext.Auto.Include(x=>x.TypeCar).Include(x=>x.CompanyDelegate).Include(x=>x.CompanyDelegate.Company);
        }

        public async Task Delete(Auto entity)
        {
            AutoRentDbContext.Auto.Remove(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public async Task<Auto> Update(Auto entity)
        {
            AutoRentDbContext.Auto.Update(entity);
            await AutoRentDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
