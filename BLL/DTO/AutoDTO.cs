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
    public class AutoDTO : IModel
    {

        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите название машины")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание машины")]
        public string Description { get; set; }
        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Введите стоимость за 1 день")]
        [Range(0,9999,ErrorMessage ="Стоимость должна быть больше 0 и меньше 9999")]
        public decimal Price { get; set; }
        [Display(Name = "Год")]
        [Required(ErrorMessage = "Введите год машины")]
        [Range(1970,2023, ErrorMessage = "год должен быть больше 1970 и меньше 2023")]
        public int Year { get; set; }
        public int TypeCarId { get; set; }
    
        public int CompanyDelegateId { get; set; }
        public string AvatarUrl { get; set; }
        public TypeCarDTO TypeCar { get; set; }
        public CompanyDelegateDTO CompanyDelegate { get; set; }

      
    }
}
