using AutoRentWebDomain.Enum;
using AutoRentWebDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWebDomain.Entity
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Arendator Arendator { get; set; }
        public CompanyDelegate CompanyDelegate { get; set; }
    }
}
