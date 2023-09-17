using AutoRentWebDomain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoRentWebDomain.ViewModels.CompanyDelegate
{
    public class CompanyDelegateViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Введите телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Название компании")]
        [Required(ErrorMessage = "Введите название компании")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Введите логин")]
        [MaxLength(20, ErrorMessage = "логин должен иметь длину меньше 20 символов")]
        [MinLength(3, ErrorMessage = "логин должен иметь длину больше 3 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        public Role Role = Role.Delegate;
    }
}
