using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoRentWebDomain.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Количество дней аренды")]
        [Required(ErrorMessage = "Укажите количество дней аренды")]
        [Range(1, 30, ErrorMessage = "Количество  дней должно быть от 1 до 30")]
        public int DayQuantity { get; set; }
        public DateTime DateStarted { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        public int CarId { get; set; }

        public string Login { get; set; }
    }
}
