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
    public class TypeCarRepository:IRepository<TypeCar>
    {
        public AutoRentDbContext AutoRentDbContext { get; set; }
        public TypeCarRepository(AutoRentDbContext autoRentDbContext)
        {
            AutoRentDbContext = autoRentDbContext;
        }
        public async Task Create(TypeCar entity)
        {
            await AutoRentDbContext.TypeCar.AddAsync(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public IEnumerable<TypeCar> GetAll()
        {
            return AutoRentDbContext.TypeCar.Include(x=>x.Autos);
        }

        public async Task Delete(TypeCar entity)
        {
            AutoRentDbContext.TypeCar.Remove(entity);
            await AutoRentDbContext.SaveChangesAsync();
        }

        public async Task<TypeCar> Update(TypeCar entity)
        {
            AutoRentDbContext.TypeCar.Update(entity);
            await AutoRentDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
