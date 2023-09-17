using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRentWebDomain.Interfaces;

namespace AutoRentWebDomain.Entity
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CompanyDelegate CompanyDelegate { get; set; }
    }
}
