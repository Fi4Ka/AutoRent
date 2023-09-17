using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoRentWebDomain.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string AutoName { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }

        public string TypeCar { get; set; }

        public string AvatarUrl { get; set; }

        public string CompanyDelegateName { get; set; }

        public string CompanyDelegateTelephone { get; set; }

        public string CompanyName { get; set; }
        public string ArendatorName { get; set; }
        public string ArendatorPhoneNumber { get; set; }
        public string ArendatorAdress { get; set; }
        public DateTime DateStart { get; set; }
        [Display(Name = "Количество дней аренды")]
        [Required(ErrorMessage = "Введите желаемое количесвто дней аренды")]
        [Range(1, 30, ErrorMessage = "Количество дней должно быть больше 0 и меньше 31")]
        public int CountDayForRent { get; set; }
        public DateTime DateEnd { get; set; }

        public string StatusOrder { get; set; }
    }
}
