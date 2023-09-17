using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRentWebDomain.Interfaces;

namespace AutoRentWebDomain.Entity
{
    public class Auto : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public int TypeCarId { get; set; }
        public TypeCar TypeCar { get; set; }
        public int CompanyDelegateId { get; set; }
        public CompanyDelegate CompanyDelegate { get; set; }
        public string AvatarUrl { get; set; }
    }
}
