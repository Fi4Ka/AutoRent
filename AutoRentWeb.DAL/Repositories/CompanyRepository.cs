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
    public class CompanyRepository:IRepository<Company>
    {
        public AutoRentDbContext AutoRentDbContext { get; set; }
        public CompanyRepository(AutoRentDbContext autoRentDbContext)
        {
            AutoRentDbContext = autoRentDbContext;
        }
        public async Task Create(Company entity)
        {
            await AutoRentDbContext.Company.AddAsync(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public async Task Delete(Company entity)
        {
            AutoRentDbContext.Company.Remove(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public IEnumerable<Company> GetAll()
        {
            return AutoRentDbContext.Company.Include(x=>x.CompanyDelegate);
        }


        public async Task<Company> Update(Company entity)
        {
            AutoRentDbContext.Company.Update(entity);
            await AutoRentDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
