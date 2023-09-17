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
    public class TypeCarDTO : IModel
    {
        public int Id { get ; set ; }
        [Display(Name = "Название типа")]
        [Required(ErrorMessage = "Введите тип")]
        public string Name { get; set; }
        [Display(Name = "Машины")]
        public IEnumerable<AutoDTO> Autos { get; set; }
    }
}
