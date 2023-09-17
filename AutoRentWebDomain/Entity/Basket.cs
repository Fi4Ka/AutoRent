using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRentWebDomain.Interfaces;

namespace AutoRentWebDomain.Entity
{
    public class Basket : IEntity
    {
        public int Id { get ; set; }
        public int ArendatorId { get;set; }
        public Arendator Arendator { get; set;}
        public IEnumerable<Order> Orders { get; set; }
    }
}
