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
    public class UserRepository:IRepository<User>
    {
        public AutoRentDbContext AutoRentDbContext { get; set; }
        public UserRepository(AutoRentDbContext autoRentDbContext)
        {
            AutoRentDbContext = autoRentDbContext;
        }
        public async Task Create(User entity)
        {
            await AutoRentDbContext.User.AddAsync(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            AutoRentDbContext.User.Remove(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public IEnumerable<User> GetAll()
        {
            return AutoRentDbContext.User.Include(x => x.Arendator.Basket).Include("CompanyDelegate.Autos.TypeCar").Include(x => x.CompanyDelegate.Company);
        }


        public async Task<User> Update(User entity)
        {
            AutoRentDbContext.User.Update(entity);
            await AutoRentDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
