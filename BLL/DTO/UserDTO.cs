using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Enum;
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
    public class UserDTO : IModel
    {
     
        public int Id { get; set; }
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Введите логин")]
        public string Login { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Вы ввели некорректный пароль")]
        public string Password { get; set; }
        [Display(Name = "Роль")]
        public string Role { get; set; }
        public ArendatorDTO Arendator { get; set; }
        public CompanyDelegateDTO CompanyDelegate { get; set; }
    }
}
