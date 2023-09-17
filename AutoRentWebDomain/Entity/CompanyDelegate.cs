using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRentWebDomain.Interfaces;

namespace AutoRentWebDomain.Entity
{
    public class CompanyDelegate : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Auto> Autos { get; set; }
    }
}
