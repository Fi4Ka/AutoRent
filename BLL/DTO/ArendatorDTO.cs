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
    public class ArendatorDTO : IModel
    {
        public int Id { get; set ; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Введите телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Введите адрес")]
        [RegularExpression("^[A-Za-zА-Яа-я0-9\\s\\.,-]+$", ErrorMessage = "Вы ввели некорректный адрес")]
        public string Adress { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public BasketDTO Basket { get; set; }
    }
}
