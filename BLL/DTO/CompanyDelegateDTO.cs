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
    public class CompanyDelegateDTO : IModel
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Введите телефон")]
        [RegularExpression("^[\\+\\d]{12}$", ErrorMessage = "Вы ввели некорректный номер телефона")]
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int CompanyId { get; set; }
        public CompanyDTO Company { get; set; }
        [Display(Name = "Машины")]
        public IEnumerable<AutoDTO> Autos { get; set; }
    }
}
