using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoRentWebDomain.ViewModels.Auto
{
    public class AutoViewModel
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
        public decimal Price { get; set; }
        [Display(Name = "Год")]
        [Required(ErrorMessage = "Введите год машины")]
        public int Year { get; set; }
        public int TypeCarId { get; set; }
        public string TypeCar { get; set; }

        public int CompanyDelegateId { get; set; }
        public string CompanyDelegateName { get; set; }
        public string CompanyDelegatePhone { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public string AvatarUrl { get; set; }
    }
}
