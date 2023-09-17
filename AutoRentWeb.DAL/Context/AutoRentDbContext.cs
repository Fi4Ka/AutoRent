using AutoRentWebDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWeb.DAL.Context
{
    public class AutoRentDbContext:DbContext
    {
        public AutoRentDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Arendator> Arendator { get; set; }

        public DbSet<Auto> Auto { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<TypeCar> TypeCar { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyDelegate> CompanyDelegate { get; set; }
    }
}
