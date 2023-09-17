using AutoRentWebDomain.Entity;
using AutoRentWebDomain.Enum;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.DTO
{
    public class OrderDTO : IModel
    {
        public int Id { get; set; }
        [Display(Name = "Дата начала аренды")]
        public DateTime DateStart = DateTime.Now;
        [Display(Name = "Дата окончания аренды")]
        [Required(ErrorMessage = "Введите дату окончания")]
        public DateTime DateEnd { get; set; }
        public int AutoId { get; set; }
        public AutoDTO Auto { get; set; }
        public int BasketId { get; set; }
        public StatusOrder StatusOrderEn { get; set; }

        public BasketDTO Basket { get; set; }
        [Display(Name = "Статус заказа")]
        [NotMapped]
        public string StatusOrder { get; set; }
    }
}
