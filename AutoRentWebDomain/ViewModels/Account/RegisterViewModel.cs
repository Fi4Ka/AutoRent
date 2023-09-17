using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRentWebDomain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Укажите логин")]
        [MaxLength(20, ErrorMessage = "Логин должен иметь длину меньше 20 символов")]
        [MinLength(3, ErrorMessage = "Логин должен иметь длину больше 3 символов")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен иметь длину больше 6 символов")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string ClientName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Введите телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Введите адрес")]
        [RegularExpression("^[A-Za-zА-Яа-я0-9\\s\\.,-]+$", ErrorMessage = "Вы ввели некорректный адрес")]
        public string Adress { get; set; }
    }
}
