using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRentWebDomain.Interfaces;

namespace AutoRentWebDomain.Entity
{
    public class TypeCar : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Auto> Autos { get; set; }
    }
}
