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
    public class CompanyDTO : IModel
    {
        public int Id { get ; set ; }
        [Display(Name = "Название компании")]
        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }
        public CompanyDelegateDTO CompanyDelegate { get; set; }
    }
}
