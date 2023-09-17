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
    public class CompanyDelegateRepository:IRepository<CompanyDelegate>
    {
        public AutoRentDbContext AutoRentDbContext { get; set; }
        public CompanyDelegateRepository(AutoRentDbContext autoRentDbContext)
        {
            AutoRentDbContext = autoRentDbContext;
        }
        public async Task Create(CompanyDelegate entity)
        {
            await AutoRentDbContext.CompanyDelegate.AddAsync(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public async Task Delete(CompanyDelegate entity)
        {
            AutoRentDbContext.CompanyDelegate.Remove(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public IEnumerable<CompanyDelegate> GetAll()
        {
            return AutoRentDbContext.CompanyDelegate.Include(x=>x.Company).Include(x=>x.Autos).Include(x=>x.User);
        }


        public async Task<CompanyDelegate> Update(CompanyDelegate entity)
        {
            AutoRentDbContext.CompanyDelegate.Update(entity);
            await AutoRentDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
