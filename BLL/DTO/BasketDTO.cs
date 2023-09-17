using AutoRentWebDomain.Entity;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.DTO
{
    public class BasketDTO : IModel
    {
        public int Id { get; set ; }
        public int ArendatorId { get; set; }
        public ArendatorDTO Arendator { get; set; }
        [Display(Name = "Заказы")]
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
