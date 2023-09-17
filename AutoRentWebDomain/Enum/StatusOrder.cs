using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoRentWebDomain.Enum
{
    public enum StatusOrder
    {
        [Display(Name = "В аренде")]
        Active = 0,
        [Display(Name = "Закончилась аренда")]
        Completed = 1,

    }
}
