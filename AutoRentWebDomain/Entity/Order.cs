using AutoRentWebDomain.Enum;
using AutoRentWebDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWebDomain.Entity
{
    public class Order : IEntity
    {
        public int Id { get ; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int AutoId { get; set; }
        public Auto Auto { get; set; }
        public int BasketId { get; set; }

        public Basket Basket { get; set; }
        public StatusOrder StatusOrder { get; set; }
    }
}
