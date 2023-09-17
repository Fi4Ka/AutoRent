using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoRentWebDomain.ViewModels.Arendator
{
    public class ProfileViewModal
    {
        public int Id { get; set; }
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
        public string UserName { get; set; }
    }
}
