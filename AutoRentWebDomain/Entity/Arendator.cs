using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRentWebDomain.Interfaces;

namespace AutoRentWebDomain.Entity
{
    public class Arendator : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Basket Basket { get; set; }
    }
}
